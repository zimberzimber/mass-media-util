using Main.Commands;
using System;
using System.Collections.Generic;
using System.IO;

namespace Main
{
    class Program
    {
        private const string WORK_DIR_CHANGE_KEY = "-";

        private static string _workingDirectory = null;
        public static string WorkingDirectory
        {
            get => _workingDirectory;
            private set
            {
                _workingDirectory = null;
                if (!string.IsNullOrWhiteSpace(value) && Directory.Exists(value))
                    _workingDirectory = value;
            }
        }

        private class CommandContainer
        {
            public CommandBase Command;
            public string Description;

            public CommandContainer(CommandBase command, string description)
            {
                Command = command;
                Description = description;
            }
        }

        static Dictionary<string, CommandContainer> Commands { get; } = new Dictionary<string, CommandContainer>()
        {
            { "1", new(new MainCommand(),                   "Mass Rename") },
            { "2", new(new PrependCommand(),                "Mass Prepend") },
            { "3", new(new ClearPrefixNumbersCommand(),     "Clear Prefix Numbers") },
            { "4", new(new ClearMetadataCommand(),          "Clear Metadata") },
        };

        static void Main(string[] args)
        {
            RequestValidPath();
            while (true)
            {
                Console.WriteLine("Select a command:");
                Console.WriteLine($"{WORK_DIR_CHANGE_KEY} : Change working directoy");

                foreach (var item in Commands)
                    Console.WriteLine($"{item.Key} : {item.Value.Description}");

                var input = Console.ReadLine();
                Console.Clear();

                if (input == WORK_DIR_CHANGE_KEY)
                    RequestValidPath();
                else if (Commands.TryGetValue(input, out var container))
                    container.Command.Run();
                else
                    Console.WriteLine("Invalid command.");
            }
        }

        private static void RequestValidPath()
        {
            Console.Clear();

            WorkingDirectory = null;
            while (WorkingDirectory == null)
            {
                Console.WriteLine("Set working directory:");
                WorkingDirectory = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Directory doesn't exist.");
            }

            Console.Clear();
        }
    }
}