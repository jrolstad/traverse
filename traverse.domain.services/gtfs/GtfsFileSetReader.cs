using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using ICSharpCode.SharpZipLib.Zip;
using traverse.domain.services.gtfs.class_maps;
using traverse.domain.services.io;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs
{
    public class GtfsFileSetReader
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICsvFactory _csvFactory;

        public GtfsFileSetReader(IFileSystem fileSystem,ICsvFactory csvFactory)
        {
            _fileSystem = fileSystem;
            _csvFactory = csvFactory;
        }

        public GtfsSet Read(string zipFilePath)
        {
            var file = _fileSystem.ReadFile(zipFilePath);

            return Read(file);
        }

        public GtfsSet Read(FileStream zipFileStream)
        {
            using (var zipFileContainer = new ZipFile(zipFileStream))
            {
                var gtfsSet = new GtfsSet();

                gtfsSet.Agencies = ReadFile<Agency,AgencyClassMap>(zipFileContainer, "agency.txt");

                return gtfsSet;
            }
        }

        private List<T> ReadFile<T,M>(ZipFile zipFile, string fileName) where M : CsvClassMap
        {
            var file = zipFile
                .Cast<ZipEntry>()
                .Where(f => f.IsFile)
                .SingleOrDefault(f => string.Equals(f.Name, fileName, StringComparison.CurrentCultureIgnoreCase));

            var fileContents = zipFile.GetInputStream(file);

            
            var configuration = new CsvConfiguration();
            configuration.RegisterClassMap<M>();
            configuration.WillThrowOnMissingField = false;

            using(var textReader = new StreamReader(fileContents))
            using (var reader = _csvFactory.CreateReader(textReader,configuration))
            {
                var data = reader.GetRecords<T>();

                return data.ToList();
            }
        }
    }
}