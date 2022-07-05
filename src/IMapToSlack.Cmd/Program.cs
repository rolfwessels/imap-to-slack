using System;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console.Cli;

namespace IMapToSlack.Cmd
{
    class Program
    {
        public static async Task<int> Main(string[] args)
        {
          Console.OutputEncoding = Encoding.UTF8;
          var app = new CommandApp<DefaultCommand>();
            app.Configure(config =>
            {
                config.SetApplicationName("IMapToSlack");
            });

            return await app.RunAsync(args);
        }
    }
}
