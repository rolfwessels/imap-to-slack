using Bumbershoot.Utilities;
using Microsoft.Extensions.Configuration;
using Slack.Webhooks;

namespace IMapToSlack.Core.Components;

public class Settings : BaseSettingsWithEncryption
{
  public Settings(IConfiguration configuration) : base(configuration,"")
  {
  }

  public string ImapHost => ReadConfigValue("ImapHost", "EN|hYeWsqC1ETNThrxqeKZBsYxYaVyZDZW4bgUK2cGIOyegOv0gRYzMQNCCo7MSmrwg");
  public int ImapPort => ReadConfigValue("ImapPort", 993);
  public string ImapUserName => ReadConfigValue("ImapUserName", "EN|8IM/ZKTMEs1ZyA98XAGiIkrfpFZAslMDHRNNn1gCAxU=");
  public string ImapPassword => ReadConfigValue("ImapPassword", "EN|WZ5YKqmS10nHYSriJqI44GSoT01uGeR0s0xEoOtVb6/PdqhmTgjljWpz9/kNqPUu");
  public string HostLink => ReadConfigValue("HostLink", "https://outlook.office.com/mail/inbox");

  public string SlackHook => ReadConfigValue("SlackHook", "EN|T91qAZkAeR+RcQEJKZmTpBOrm8cngFSNlLgJ1yoh85Xf6LWlf+lChnKlrn7tBIbK7JID616/BK4APm2upL/au/DzODiYDFUxweH6fkxl+AKx5FFt36siNvT8XvXbZiPy");
  public string SlackEmoji => ReadConfigValue("SlackEmoji", Emoji.Email);
  public string SlackFromUser => ReadConfigValue("SlackFromUser", "ImapToSlack");
}
