using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bumbershoot.Utilities.Helpers;
using MailKit;
using Slack.Webhooks;

namespace IMapToSlack.Core.Components;

public class SlackHook
{
  private readonly SlackClient _slackClient;

  public SlackHook(Settings settings)
  {
    _slackClient = new SlackClient(settings.SlackHook);
  }

  public async Task Send(params SlackMessage[] messages)
  {
    foreach (var message in messages) 
      await _slackClient.PostAsync(message);
  }

  public static SlackMessage BuildMessage(params MailSummary[] summary)
  {
    var slackMessage = new SlackMessage
    {
      IconEmoji = Emoji.Email,
      Username = "ImapToSlack"
    };
    ;
    slackMessage.Attachments = summary.Select(x =>
    {
      var text = $"*{x.Subject}* <https://outlook.office.com/mail/|:mailbox_with_mail:>";
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

  public static SlackMessage BuildMessage(string subject, string from)
  {
     
    var slackMessage = new SlackMessage
    {
      IconEmoji = Emoji.Email,
      Username = "ImapToSlack"
    };
    var text = $"*{subject}* <https://outlook.office.com/mail/|:mailbox_with_mail:>";
    var slackAttachment = new SlackAttachment
    {
      Fallback =text,
      Footer = from,
      Text = text,
      Color = "#00D100"
    };
    slackMessage.Attachments = new List<SlackAttachment> { slackAttachment };
    return slackMessage;
  }
}


