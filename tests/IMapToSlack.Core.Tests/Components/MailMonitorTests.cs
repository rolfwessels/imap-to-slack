using System.Threading.Tasks;
using Bumbershoot.Utilities.Helpers;
using FluentAssertions;
using IMapToSlack.Cmd;
using IMapToSlack.Core.Components;
using NUnit.Framework;

namespace IMapToSlack.Core.Tests.Components;

public class MailMonitorTests
{
  [Test]
  [Explicit]
  [Category("Integration")]
  public async Task Connect_GivenConnectionDetails_ShouldConnectToImapServer()
  {
    // arrange
    var mailMonitor = new MailMonitor(new Settings(ConfigurationFactory.Load()));
    // action
    var inboxUnreadMessages = await mailMonitor.GetInboxUnreadMessages();
    // assert
    inboxUnreadMessages.Dump("").Should().HaveCountGreaterOrEqualTo(0);
  }

}
