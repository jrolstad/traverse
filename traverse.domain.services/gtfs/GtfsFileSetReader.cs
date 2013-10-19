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

        public GtfsSet Read(Stream zipFileStream)
        {
            using (var zipFileContainer = new ZipFile(zipFileStream))
            {
                var gtfsSet = new GtfsSet();

                gtfsSet.Agencies = ReadFile<Agency,AgencyClassMap>(zipFileContainer, "agency.txt");
                gtfsSet.Calendars = ReadFile<Calendar, CalendarClassMap>(zipFileContainer, "calendar.txt");
                gtfsSet.CalendarDates = ReadFile<CalendarDate, CalendarDateClassMap>(zipFileContainer, "calendar_dates.txt");
                gtfsSet.FareAttributes = ReadFile<FareAttribute, FareAttributeClassMap>(zipFileContainer, "fare_attributes.txt");
                gtfsSet.FareRules = ReadFile<FareRule, FareRuleClassMap>(zipFileContainer, "fare_rules.txt");
                gtfsSet.FeedInfo = ReadFile<FeedInfo, FeedInfoClassMap>(zipFileContainer, "feed_info.txt");
                gtfsSet.Frequencies = ReadFile<Frequency, FrequencyClassMap>(zipFileContainer, "frequencies.txt");
                gtfsSet.Routes = ReadFile<Route, RouteClassMap>(zipFileContainer, "routes.txt");
                gtfsSet.Shapes = ReadFile<Shape, ShapeClassMap>(zipFileContainer, "shapes.txt");
                gtfsSet.StopTimes = ReadFile<StopTime, StopTimeClassMap>(zipFileContainer, "stop_times.txt");
                gtfsSet.Stops = ReadFile<Stop, StopClassMap>(zipFileContainer, "stops.txt");
                gtfsSet.Transfers = ReadFile<Transfer, TransferClassMap>(zipFileContainer, "transfers.txt");
                gtfsSet.Trips = ReadFile<Trip, TripClassMap>(zipFileContainer, "trips.txt");

                return gtfsSet;
            }
        }

        private List<T> ReadFile<T,M>(ZipFile zipFile, string fileName) where M : CsvClassMap
        {
            var file = GetFile(zipFile, fileName);

            if (file == null) return new List<T>();
                
            var fileContents = ReadFile(zipFile, file);
            var parsedData = ReadDataFromFile<T,M>(fileContents);

            return parsedData;
        }

        private static ZipEntry GetFile(ZipFile zipFile, string fileName)
        {
            var file = zipFile
                .Cast<ZipEntry>()
                .Where(f => f.IsFile)
                .SingleOrDefault(f => string.Equals(f.Name, fileName, StringComparison.CurrentCultureIgnoreCase));
            return file;
        }

        private static Stream ReadFile(ZipFile zipFile, ZipEntry file)
        {
            var fileContents = zipFile.GetInputStream(file);
            return fileContents;
        }

        private List<T> ReadDataFromFile<T, M>(Stream fileContents) where M : CsvClassMap
        {
            var configuration = CreateFileReaderConfiguration<M>();

            using (var textReader = new StreamReader(fileContents))
            using (var reader = _csvFactory.CreateReader(textReader, configuration))
            {
                var data = reader.GetRecords<T>();

                return data.ToList();
            }
        }

        private static CsvConfiguration CreateFileReaderConfiguration<M>() where M : CsvClassMap
        {
            var configuration = new CsvConfiguration();
            configuration.RegisterClassMap<M>();
            configuration.WillThrowOnMissingField = false;
            configuration.SkipEmptyRecords = true;
            return configuration;
        }

    }
}