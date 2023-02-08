using System;
using System.IO;
using System.Linq;

namespace Main.Commands
{
    public abstract class CommandBase
    {
        private static readonly string[] ALLOWED_EXTENSIONS = new string[]
        {
            // Video
            // ".mkv", ".ogv", ".avi", ".wmv", ".asf", ".mp4", ".m4p", ".m4v", ".mpe", ".mpg", ".mpe", ".mpv", ".mpg", ".m2v", ".webm",

            // Audio
            ".aa", ".aax", ".aac", ".aiff", ".ape", ".dsf", ".flac", ".m4a", ".m4b", ".m4p", ".mp3", ".mpc", ".mpp", ".ogg", ".oga", ".wav", ".wma", ".wv",

            // Images
            ".png", ".jpg", ".jpeg"
        };

        public abstract void Run();

        protected static string GetPath() => Program.WorkingDirectory;

        protected virtual void Done()
        {
            Console.WriteLine("\nAll done! Press any key to continue.");
            Console.ReadKey();
        }

        protected static void ForFilesInDir(string dir, Action<string> action)
        {
            string[] files = Directory.GetFiles(dir);
            foreach (var fullPath in files)
            {
                if (ALLOWED_EXTENSIONS.Contains(Path.GetExtension(fullPath)))
                    action(Path.GetFileName(fullPath));
            }
        }
    }
}
