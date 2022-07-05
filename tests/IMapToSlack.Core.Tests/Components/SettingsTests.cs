using System;
using FluentAssertions;
using IMapToSlack.Cmd;
using IMapToSlack.Core.Components;
using NUnit.Framework;

namespace IMapToSlack.Core.Tests.Components;

public class SettingsTests
{
  [Test]
  public void SlackHook_GivenEncryptedValue_ShouldReturnString()
  {
    // arrange

    var settings = new Settings(ConfigurationFactory.Load());
    
    // action
    var settingsSlackHook = settings.SlackHook;
    // assert
    Console.Out.WriteLine(settings.GetEncryptedValue(settings.ImapHost));
    settingsSlackHook.Should().StartWith("http");
  }
  

}
