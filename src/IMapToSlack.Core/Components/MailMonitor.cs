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
  private static readonly ILogger _log = Log.ForContext(MethodBase.GetCurrentMethod()!.DeclaringType!);
  private readonly string _host;
  private readonly int _port;
  private readonly string _userName;
  private readonly string _password;

  public MailMonitor(Settings settings)
  {
    _host = settings.ImapHost;
    _port = settings.ImapPort;
    _userName = settings.ImapUserName;
    _password = settings.ImapPassword;
  }

  public async Task<List<MailSummary>> GetInboxUnreadMessages()
  {
    using var client = new ImapClient();
    await client.ConnectAsync(_host, _port, true);
    await client.AuthenticateAsync(_userName, _password);
    try
    {
      var inbox = client.Inbox;
      await inbox.OpenAsync(FolderAccess.ReadOnly);

      var query = SearchQuery.All;
      var uids = await inbox.SearchAsync(query);
      var items = (await inbox.FetchAsync(uids.Reverse().Take(20).ToList(), MessageSummaryItems.Full)).Reverse();

      var mailSummaries = items.Where(item => !item.Flags!.Value.HasFlag(MessageFlags.Seen))
        .Select(item => new MailSummary(item.Envelope.Subject, item.Envelope.From.OfType<MailboxAddress>().Select(f => f.Address.ToLower()).StringJoin()));
      return mailSummaries.ToList();
    }
    catch (Exception e)
    {
        _log.Error(e,e.Message);
        throw;
    }
    finally{
      await client.DisconnectAsync(true);
    }
   



    
  }
  
  private void Imap()
  {
    using (var client = new ImapClient())
    {
      client.Connect(_host, _port, true);

      client.Authenticate(_userName, _password);

      // The Inbox folder is always available on all IMAP servers...
      var inbox = client.Inbox;
      inbox.Open(FolderAccess.ReadOnly);


      var query = SearchQuery.All;
      var uids = inbox.Search(query);
      var items = inbox.Fetch(uids.Reverse().Take(20).ToList(), MessageSummaryItems.Full ).Reverse();

      items.Where(item=> !item.Flags!.Value.HasFlag(MessageFlags.Seen))
        .Select(item=>$" {item.Envelope.Subject} {item.Envelope.From.OfType<MailboxAddress>().Select(f=>f.Address.ToLower()).StringJoin()}")
        .Dump("");



      client.Disconnect(true);
    }
  }
}

public record MailSummary(string Subject, string From);
