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

  public async Task<int> PostUnreadMessages(int maxRecentMessagesToCheck = 20)
  {
    var unreadMessages = await _mailMonitor.GetInboxUnreadMessages(maxRecentMessagesToCheck);
    if (unreadMessages.Any())
      await _slackHook.Send(SlackHook.BuildMessage(unreadMessages.ToArray()));
    return unreadMessages.Count;
  }
}
