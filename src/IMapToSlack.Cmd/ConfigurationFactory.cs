using Microsoft.Extensions.Configuration;

namespace IMapToSlack.Cmd;

public class ConfigurationFactory
{
  public static IConfiguration Load()
  {
    return Apply(new ConfigurationBuilder()).Build();
  }

  public static IConfigurationBuilder Apply(IConfigurationBuilder builder)
  {
    return builder
      .AddJsonFile("appsettings.json", true, false)
      .AddEnvironmentVariables();
  }
}
