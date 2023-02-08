
namespace Main.Commands
{
    class ClearMetadataCommand : CommandBase
    {

        public override void Run()
        {
            var dir = GetPath();

            ForFilesInDir(dir, file =>
            {
                var tfile = TagLib.File.Create($"{dir}\\{file}");
                if (!tfile.Tag.IsEmpty)
                {
                    tfile.Tag.Clear();
                    tfile.Save();
                }
            });

            Done();
        }
    }
}