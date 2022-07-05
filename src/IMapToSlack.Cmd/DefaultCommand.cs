using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using IMapToSlack.Core.Components;
using Spectre.Console;
using Spectre.Console.Cli;

namespace IMapToSlack.Cmd;

public sealed class DefaultCommand : AsyncCommand<DefaultCommand.Arguments>
{
  public sealed class Arguments : CommandSettings
  {
    [CommandArgument(0, "[run]")]
    [Description("Posting mail to slack.")]
    public string? Name { get; set; }

    [CommandOption("-m|--max-emails")]
    [Description("Max emails to check")]
    public int MaxItems { get; set; } = 10;
  }

  public override async Task<int> ExecuteAsync(CommandContext context, Arguments arguments)
  {
    if (arguments.Name == null || arguments.Name.ToLower() != "run")
    {
      AnsiConsole.MarkupLine("❓ Type [blue]--help[/] for help");
      return 1;
    }

    switch (arguments.Name.ToLower())
    {
      case "run":

        var configuration = ConfigurationFactory.Load();
        var settings = new Settings(configuration);
        var slackHook = new MailToSlack(new MailMonitor(settings), new SlackHook(settings));
        // action
        var result = 0;
        await AnsiConsole.Status()
          .Spinner(Spinner.Known.Default)
          .StartAsync("Reading mail...",
            async ctx => { result = await slackHook.PostUnreadMessages(arguments.MaxItems); });
        AnsiConsole.MarkupLine($"Sent [green]{result}[/] new mail 📧 items to slack.");
        break;
    }

    return 0;
  }
}
