using System;
using System.Linq;

namespace narwhal
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Narwhal:\n" +
                    "\n" +
                    "A .NET Core CLI to save and load docker volumes to tarballs" +
                    "\n" +
                    "Use narwhal --help to see list of commands\n");
                return;
            }
            if(args.Length == 1)
            {
                if(args[0] == "--help")
                {
                    Console.WriteLine("narwhal <message> : prints message in caps");
                }
                else
                {
                    Console.WriteLine(args[0].ToUpper());
                }
            }
        }
    }
}
