using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kirinnee.ConsoleHelp;
using Kirinnee.Helper;

namespace narwhal
{
    public class SaveCommand : ICommandObject
    {
        public string Name { get; } = "Save";
        public string Description { get; } = "Saves a docker volume as a tarball";
        public string Usage { get; } = "narwhal save <volume name> <tarball name> <relative path to save to>";
        public string[] Command { get; } = {"save"};
        public string PerfectCommand => string.Join("", Command);
        public IEnumerable<string> PossibleFlags { get; } = new string[] { };
        public IEnumerable<string> PossibleVariables { get; } = new string[] { };

        public Task<CommandResult> Execute(string[] fullCommand, string[] rawArgs, Dictionary<string, string> variables,
            string[] flags)
        {
            Console.WriteLine(rawArgs.Length);
            var volume = rawArgs[0];
            var tarball = rawArgs.Length > 1 ? rawArgs[1] : "data";
            var path = rawArgs.Length > 2 ? rawArgs[2] : "./";
            var narwhal = new Narwhal(false);
            var errors = narwhal.Save(volume, tarball, path);
            var enumerable = errors as string[] ?? errors.ToArray();
            return Task.FromResult(!enumerable.Any()
                ? new CommandResult(true, "Saved!")
                : new CommandResult(false, enumerable.JoinBy("\n")));
        }
    }
}