using System.Threading.Tasks;
using IMapToSlack.Cmd;
using IMapToSlack.Core.Components;
using NUnit.Framework;

namespace IMapToSlack.Core.Tests.Components;

public class MailToSlackTests
{
  [Test]
  [Explicit]
  [Category("Integration")]
  public async Task IntegrationTest()
  {
    // arrange
    var settings = new Settings(ConfigurationFactory.Load());
    var mailToSlack = new MailToSlack(new MailMonitor(settings), new SlackHook(settings));
    // action
    await mailToSlack.PostUnreadMessages();
    // assert
  }


}
