using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using traverse.domain.services.io;
using traverse.orca.models;

namespace traverse.domain.services.orca
{
    public class OrcaFileReader
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICsvFactory _csvFactory;

        public OrcaFileReader(IFileSystem fileSystem, ICsvFactory csvFactory)
        {
            _fileSystem = fileSystem;
            _csvFactory = csvFactory;
        }

        public List<OrcaTransaction> Read(string filePath)
        {
            var file = _fileSystem.ReadFile(filePath);

            return Read(file);
        }

        public List<OrcaTransaction> Read(Stream fileStream)
        {
            var configuration = CreateFileReaderConfiguration();

            using (var textReader = new StreamReader(fileStream))
            using (var reader = _csvFactory.CreateReader(textReader, configuration))
            {
                var data = reader.GetRecords<OrcaTransaction>();

                return data.ToList();
            }
        }
        private static CsvConfiguration CreateFileReaderConfiguration()
        {
            var configuration = new CsvConfiguration();
            configuration.WillThrowOnMissingField = false;
            configuration.SkipEmptyRecords = true;
            configuration.Delimiter = "\t";

            return configuration;
        }
    }
}