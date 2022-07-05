using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Spectre.Console;
using Spectre.Console.Cli;

namespace IMapToSlack.Cmd
{
    public sealed class DefaultCommand : Command<DefaultCommand.Settings>
    {

        public sealed class Settings : CommandSettings
        {
            [CommandArgument(0, "[process]")]
            [Description("The example to run.\nIf none is specified, all examples will be listed")]
            public string? Name { get; set; }

            [CommandOption("-t|--table")]
            [Description("Show table")]
            public bool Table { get; set; }

        }


        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            if (settings.Name == null)
            {
                AnsiConsole.MarkupLine("Type [blue]--help[/] for help");
                return 1;
            }

            AnsiConsole.MarkupLine($"[green]Processing `{settings.Name}`.[/]");

            if (settings.Table)
            {
                var examples = new [] { new  { Test = "test" }, new { Test = "test2" }, }.ToList();
                var table = new Table { Border = TableBorder.Rounded }.Expand();
                table.AddColumn(new TableColumn("[yellow]Example[/]") { NoWrap = true, });
                table.AddColumn(new TableColumn("[grey]Description[/]"));
            
                foreach (var group in examples.GroupBy(ex => ex.Test))
                {
                    table.AddRow(group.Key,group.Count().ToString());
                    table.AddEmptyRow();
                }
                
                AnsiConsole.Render(table);
            }
            return 0;
        }
    }
}