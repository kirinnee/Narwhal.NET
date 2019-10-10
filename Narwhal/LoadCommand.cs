using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kirinnee.ConsoleHelp;
using Kirinnee.Helper;

namespace narwhal
{
    public class LoadCommand : ICommandObject
    {
        public string Name { get; } = "Load";
        public string Description { get; } = "Load a tarball into a name volumed";
        public string Usage { get; } = "narwhal load <path to tarball> <volume name>";
        public string[] Command { get; } = {"load"};
        public string PerfectCommand => string.Join("", Command);
        public IEnumerable<string> PossibleFlags { get; } = new string[] { };
        public IEnumerable<string> PossibleVariables { get; } = new string[] { };

        public Task<CommandResult> Execute(string[] fullCommand, string[] rawArgs, Dictionary<string, string> variables,
            string[] flags)
        {
            if (rawArgs.Length < 2)
            {
                return Task.FromResult(new CommandResult(false, "At least 2 argument is needed"));
            }

            var path = rawArgs[0];
            var volume = rawArgs[1];

            var narwhal = new Narwhal(false);
            var errors = narwhal.Load(volume, path);
            var enumerable = errors as string[] ?? errors.ToArray();
            return Task.FromResult(!enumerable.Any()
                ? new CommandResult(true, $"Loaded into volume <{volume}>!")
                : new CommandResult(false, enumerable.JoinBy("\n")));
        }
    }
}