using Bumbershoot.Utilities;
using Microsoft.Extensions.Configuration;

namespace IMapToSlack.Core.Components;

public class Settings : BaseSettingsWithEncryption
{
  public Settings(IConfiguration configuration) : base(configuration,"")
  {
  }

  public string SlackHook => ReadConfigValue("SlackHook", "EN|kUbMPdtfTppqMo9cAiLdUa0/41sXptcL3LiP8zy0axcD3zSqNn4cWIujZdUECdNGuzjzkmQRZH7EH0gKsDJZ5ftnxIa+1xCXPidAkchak+ia8tHQEJe6V6goAMZ78RQZ");
  public string ImapHost => ReadConfigValue("ImapHost", "EN|hYeWsqC1ETNThrxqeKZBsYxYaVyZDZW4bgUK2cGIOyegOv0gRYzMQNCCo7MSmrwg");
  public int ImapPort => ReadConfigValue("ImapPort", 993);
  public string ImapUserName => ReadConfigValue("ImapUserName", "EN|8IM/ZKTMEs1ZyA98XAGiIkrfpFZAslMDHRNNn1gCAxU=");
  public string ImapPassword => ReadConfigValue("ImapPassword", "EN|WZ5YKqmS10nHYSriJqI44GSoT01uGeR0s0xEoOtVb6/PdqhmTgjljWpz9/kNqPUu");
  
}
