using System;
using System.IO;

namespace Main.Commands
{
    class PrependCommand : CommandBase
    {
        public override void Run()
        {
            var dir = GetPath();

            Console.WriteLine("What to prepend:");
            var prep = Console.ReadLine();

            ForFilesInDir(dir, file =>
            {
                var oldPath = $"{dir}\\{file}";
                var newPath = $"{dir}\\{prep + file}";
                Console.WriteLine($"Renaming ${oldPath} to ${newPath}...");
                File.Move(oldPath, newPath);
            });

            Done();
        }
    }
}