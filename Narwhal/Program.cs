using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kirinnee.ConsoleHelp;

namespace narwhal
{
    public static class Program
    {
        internal static void Main(string[] args)
        {
            var exe = new CommandExecutor("Narwhal", "Simple Command line to load and save docker volumes", "0.0.3",
                new List<ICommandObject> {new SaveCommand(), new LoadCommand()});
            Async(args, exe).GetAwaiter().GetResult();
        }

        static async Task Async(string[] args, ICommandExecutor exe)
        {
            await exe.ExecuteCommand(args);
        }
    }
}