using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bumbershoot.Utilities.Helpers;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using Serilog;

namespace IMapToSlack.Core.Components;

public class MailMonitor
{
  private readonly Settings _settings;
  private static readonly ILogger _log = Log.ForContext(MethodBase.GetCurrentMethod()!.DeclaringType!);
  private readonly string _host;
  private readonly int _port;
  private readonly string _userName;
  private readonly string _password;

  public MailMonitor(Settings settings)
  {
    _settings = settings;
    _host = settings.ImapHost;
    _port = settings.ImapPort;
    _userName = settings.ImapUserName;
    _password = settings.ImapPassword;
  }

  public async Task<List<MailSummary>> GetInboxUnreadMessages(int maxRecentMessagesToCheck)
  {
    using var client = new ImapClient();
    await client.ConnectAsync(_host, _port, true);
    await client.AuthenticateAsync(_userName, _password);
    try
    {
      var inbox = client.Inbox;
      await inbox.OpenAsync(FolderAccess.ReadOnly);
      var items = await QueryFolder(maxRecentMessagesToCheck, inbox);
      return items
        .Where(IsUnRead)
        .Select(ToSummary)
        .ToList();
    }
    finally{
      await client.DisconnectAsync(true);
    } 
  }

  private static async Task<IEnumerable<IMessageSummary>> QueryFolder(int maxRecentMessagesToCheck, IMailFolder inbox)
  {
    var query = SearchQuery.All;
    var uids = await inbox.SearchAsync(query);
    var items = (await inbox.FetchAsync(uids.Reverse().Take(maxRecentMessagesToCheck).ToList(), MessageSummaryItems.Full))
      .Reverse();
    return items;
  }

  private static bool IsUnRead(IMessageSummary item)
  {
    return !item.Flags!.Value.HasFlag(MessageFlags.Seen);
  }

  private MailSummary ToSummary(IMessageSummary item)
  {
    return new MailSummary(item.Envelope.Subject, item.Envelope.From.OfType<MailboxAddress>().Select(f => f.Address.ToLower()).StringJoin(), _settings.HostLink);
  }
}
