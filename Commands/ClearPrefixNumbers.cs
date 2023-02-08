using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Main.Commands
{
    partial class ClearPrefixNumbersCommand : CommandBase
    {
        public override void Run()
        {
            var dir = GetPath();

            ForFilesInDir(dir, file =>
            {
                var oldPath = $"{dir}\\{file}";
                var newPath = $"{dir}\\{NumbersRegex().Replace(file, "")}";

                if (oldPath != newPath)
                {
                    Console.WriteLine($"Renaming ${oldPath} to ${newPath}...");
                    try
                    {
                        File.Move(oldPath, newPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($">> FAILED!\n{ex}");
                    }
                }
            });

            Done();
        }

        [GeneratedRegex("^[\\s0-9]+")]
        private static partial Regex NumbersRegex();
    }
}