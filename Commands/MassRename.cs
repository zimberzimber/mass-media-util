using System;
using System.IO;

namespace Main.Commands
{
    class MainCommand : CommandBase
    {
        public override void Run()
        {
            var dir = GetPath();

            Console.WriteLine("Replace what:");
            string sub = Console.ReadLine();

            Console.WriteLine("With what:");
            string rep = Console.ReadLine();

            ForFilesInDir(dir, file =>
            {
                var oldName = Path.GetFileNameWithoutExtension(file);
                if (!oldName.Contains(sub))
                    return;

                var ext = Path.GetExtension(file);
                var newName = oldName.Replace(sub, rep);

                var fullPathNew = $"{dir}\\{newName}{ext}";
                Console.WriteLine($"\nRenaming {oldName}{ext} to {newName}{ext}...");
                File.Move($"{dir}\\{file}", fullPathNew);
            });

            Done();
        }
    }
}