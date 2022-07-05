using System.Linq;
using System.Threading.Tasks;

namespace IMapToSlack.Core.Components;

public class MailToSlack
{
  private readonly MailMonitor _mailMonitor;
  private readonly SlackHook _slackHook;

  public MailToSlack(MailMonitor mailMonitor, SlackHook slackHook)
  {
    _mailMonitor = mailMonitor;
    _slackHook = slackHook;
  }

  public async Task PostUnreadMessages()
  {
    var unreadMessages = await _mailMonitor.GetInboxUnreadMessages(20);
    await _slackHook.Send(SlackHook.BuildMessage(unreadMessages.ToArray()));
  }
}
