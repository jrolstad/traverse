using System.IO;

namespace traverse.domain.services.io
{
    public interface IFileSystem
    {
        FileStream ReadFile(string path);
    }
}