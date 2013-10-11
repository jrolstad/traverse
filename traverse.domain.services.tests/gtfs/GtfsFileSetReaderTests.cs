using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using NUnit.Framework;
using traverse.domain.services.gtfs;
using traverse.domain.services.io;
using traverse.gtfs.models;

namespace traverse.domain.services.tests.gtfs
{
    [TestFixture]
    public class GtfsFileSetReaderTests
    {
        private GtfsSet _result;

        [TestFixtureSetUp]
        public void When_reading_a_zip_file_into_a_gtfs_set()
        {
            // Arrange
            var zipFile = GetSampleZipFile();

            var reader = new GtfsFileSetReader(new FileSystem(), new CsvFactory());

            // Act
            _result = reader.Read(zipFile);
        }


        [Test]
        public void Then_the_agencies_are_read()
        {
            // Assert
            Assert.That(_result.Agencies,Has.Count.EqualTo(1));
        }

        [Test]
        public void Then_the_agency_id_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyId,Is.EqualTo("SoundTransit"));
        }

        [Test]
        public void Then_the_agency_name_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyName, Is.EqualTo("Sound Transit"));
        }

        [Test]
        public void Then_the_agency_url_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyUrl, Is.EqualTo("http://www.soundtransit.org"));
        }

        [Test]
        public void Then_the_agency_language_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyLanguage, Is.EqualTo("EN"));
        }

        [Test]
        public void Then_the_agency_time_zone_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyTimeZone, Is.EqualTo(@"America/Los_Angeles"));
        }

        [Test]
        public void Then_the_agency_phone_number_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyPhone, Is.EqualTo(@"(800) 201-4900"));
        }

        private Stream GetSampleZipFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "traverse.domain.services.tests.resources.gtfs_data.zip";

            var stream = assembly.GetManifestResourceStream(resourceName);

            return stream;
        }
    }
}