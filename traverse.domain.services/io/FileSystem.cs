using System.IO;

namespace traverse.domain.services.io
{
    public class FileSystem : IFileSystem
    {
        public FileStream ReadFile(string path)
        {
            return File.OpenRead(path);
        }
    }
}