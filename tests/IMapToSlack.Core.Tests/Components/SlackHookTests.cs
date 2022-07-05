using System.Threading.Tasks;
using IMapToSlack.Cmd;
using IMapToSlack.Core.Components;
using NUnit.Framework;

namespace IMapToSlack.Core.Tests.Components;

public class SlackHookTests
{
  [Test]
  [Explicit]
  [Category("Integration")]
  public async Task Send_GivenMessage_ShouldPostToSlack()
  {
    // arrange
    var slackHook = new SlackHook(new Settings(ConfigurationFactory.Load()));
    var buildMessage = SlackHook.BuildMessage(new MailSummary("Android - users", "CvD@circulor.com"),new MailSummary("His", "sample@asfdasdm.com"));
    // action
    await slackHook.Send(buildMessage);
    // assert
  }

}
