using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace IMapToSlack.Cmd
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var app = new CommandApp<DefaultCommand>();
            app.Configure(config =>
            {
                config.SetApplicationName("I Map To Slack");
            });

            return await app.RunAsync(args);
        }
    }
}
