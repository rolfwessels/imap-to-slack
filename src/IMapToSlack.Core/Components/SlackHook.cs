using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slack.Webhooks;

namespace IMapToSlack.Core.Components;

public class SlackHook
{
  private readonly Settings _settings;
  private readonly SlackClient _slackClient;

  public SlackHook(Settings settings)
  {
    _settings = settings;
    _slackClient = new SlackClient(settings.SlackHook);
  }

  public async Task Send(params SlackMessage[] messages)
  {
    foreach (var message in messages)
    {
      message.IconEmoji = _settings.SlackEmoji;
      message.Username = _settings.SlackFromUser;
      await _slackClient.PostAsync(message);
    }
  }

  public static SlackMessage BuildMessage(params MailSummary[] summary)
  {
    var slackMessage = new SlackMessage();

    ;
    slackMessage.Attachments = summary.Select(x =>
    {
      var text = $"*{x.Subject}* <{x.Link}:mailbox_with_mail:>";
      return new SlackAttachment
      {
        Fallback = text,
        Footer = x.From,
        Text = text,
        Color = "#00D100"
      };
    }).ToList();

    return slackMessage;
  }
  
}


