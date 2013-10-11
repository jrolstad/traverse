using System;
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
        public void Agency_Then_the_agencies_are_read()
        {
            // Assert
            Assert.That(_result.Agencies,Has.Count.EqualTo(1));
        }

        [Test]
        public void Agency_Then_the_agency_id_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyId,Is.EqualTo("SoundTransit"));
        }

        [Test]
        public void Agency_Then_the_agency_name_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyName, Is.EqualTo("Sound Transit"));
        }

        [Test]
        public void Agency_Then_the_agency_url_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyUrl, Is.EqualTo("http://www.soundtransit.org"));
        }

        [Test]
        public void Agency_Then_the_agency_language_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyLanguage, Is.EqualTo("EN"));
        }

        [Test]
        public void Agency_Then_the_agency_time_zone_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyTimeZone, Is.EqualTo(@"America/Los_Angeles"));
        }

        [Test]
        public void Agency_Then_the_agency_phone_number_is_read()
        {
            // Assert
            Assert.That(_result.Agencies.First().AgencyPhone, Is.EqualTo(@"(800) 201-4900"));
        }

        [Test]
        public void Calendar_Then_the_calendars_are_read()
        {
            // Assert
            Assert.That(_result.Calendars,Has.Count.EqualTo(3));
        }

        [Test]
        public void Calendar_Then_the_service_id_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Select(c=>c.ServiceId).Distinct().ToList(),Is.EquivalentTo(new[]{"SU","SA","WD"}));
        }

        [Test]
        public void Calendar_Then_monday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c=>c.ServiceId == "WD").Monday,Is.EqualTo(true));
        }

        [Test]
        public void Calendar_Then_tuesday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").Tuesday, Is.EqualTo(true));
        }

        [Test]
        public void Calendar_Then_wednesday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").Wednesday, Is.EqualTo(true));
        }

        [Test]
        public void Calendar_Then_thursday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").Thursday, Is.EqualTo(true));
        }

        [Test]
        public void Calendar_Then_friday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").Friday, Is.EqualTo(true));
        }

        [Test]
        public void Calendar_Then_saturday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").Saturday, Is.EqualTo(false));
        }

        [Test]
        public void Calendar_Then_sunday_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").Sunday, Is.EqualTo(false));
        }

        [Test]
        public void Calendar_Then_the_start_date_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").StartDate, Is.EqualTo(new DateTime(2013,9,29)));
        }

        [Test]
        public void Calendar_Then_the_end_date_is_read()
        {
            // Assert
            Assert.That(_result.Calendars.Single(c => c.ServiceId == "WD").EndDate, Is.EqualTo(new DateTime(2014, 2, 15)));
        }

        [Test]
        public void CalendarDates_Then_the_calendar_dates_are_read()
        {
            // Assert
            Assert.That(_result.CalendarDates, Has.Count.EqualTo(6));
        }

        [Test]
        public void CalendarDates_Then_the_service_id_is_read()
        {
            // Assert
            Assert.That(_result.CalendarDates.Select(c => c.ServiceId).Distinct().ToList(), Is.EquivalentTo(new[] { "SU", "WD" }));
        }

        [Test]
        public void Calendar_Then_the_date_is_read()
        {
            // Assert
            Assert.That(_result.CalendarDates.Last().Date, Is.EqualTo(new DateTime(2014, 1, 1)));
        }

        [Test]
        public void Calendar_Then_the_exception_type_is_read()
        {
            // Assert
            Assert.That(_result.CalendarDates.SingleOrDefault(d=>d.ServiceId == "SU" && d.Date == new DateTime(2013,11,28)).ExceptionType,Is.EqualTo(ExceptionType.ServiceAddedForTheSpecifiedDate));
            Assert.That(_result.CalendarDates.SingleOrDefault(d=>d.ServiceId == "WD" && d.Date == new DateTime(2013,11,28)).ExceptionType,Is.EqualTo(ExceptionType.ServiceRemovedForTheSpecifiedDate));
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