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
            Assert.That(_result.CalendarDates.Single(d => d.ServiceId == "SU" && d.Date == new DateTime(2013, 11, 28)).ExceptionType, Is.EqualTo(ExceptionType.ServiceAddedForTheSpecifiedDate));
            Assert.That(_result.CalendarDates.Single(d => d.ServiceId == "WD" && d.Date == new DateTime(2013, 11, 28)).ExceptionType, Is.EqualTo(ExceptionType.ServiceRemovedForTheSpecifiedDate));
        }

        [Test]
        public void FareAttributes_Then_the_fare_attributes_are_read()
        {
            // Assert
            Assert.That(_result.FareAttributes, Has.Count.EqualTo(25));
        }

        [Test]
        public void FareAttributes_Then_the_fare_id_is_read()
        {
            // Assert
            Assert.That(_result.FareAttributes.Any(f => string.IsNullOrEmpty(f.FareId)), Is.False);
        }

        [Test]
        public void FareAttributes_Then_the_price_is_read()
        {
            // Assert
            Assert.That(_result.FareAttributes.Single(f=>f.FareId == "221").Price,Is.EqualTo(2.5));
        }

        [Test]
        public void FareAttributes_Then_the_currency_type_is_read()
        {
            // Assert
            Assert.That(_result.FareAttributes.Single(f => f.FareId == "221").CurrencyType, Is.EqualTo("USD"));
        }

        [Test]
        public void FareAttributes_Then_the_payment_method_is_read()
        {
            // Assert
            Assert.That(_result.FareAttributes.Single(f => f.FareId == "221").PaymentMethod, Is.EqualTo(FarePaymentMethod.PaidBeforeBoarding));
            Assert.That(_result.FareAttributes.Single(f => f.FareId == "36").PaymentMethod, Is.EqualTo(FarePaymentMethod.PaidOnBoard));
        }

        [Test]
        public void FareAttributes_Then_the_transfer_duration_is_read()
        {
            // Assert
            Assert.That(_result.FareAttributes.Single(f => f.FareId == "221").TransferDuration, Is.EqualTo(7200));
        }

        [Test]
        public void FareRules_Then_the_fare_rules_are_read()
        {
            // Assert
            Assert.That(_result.FareRules, Has.Count.EqualTo(79));
        }

        [Test]
        public void FareRules_Then_the_fare_id_is_read()
        {
            // Assert
            Assert.That(_result.FareRules.Any(f => string.IsNullOrEmpty(f.FareId)), Is.False);
        }

        [Test]
        public void FareRules_Then_the_origin_id_is_read()
        {
            // Assert
            Assert.That(_result.FareRules.First().OriginId, Is.EqualTo("S_ST"));
        }

        [Test]
        public void FareRules_Then_the_destination_id_is_read()
        {
            // Assert
            Assert.That(_result.FareRules.First().DestinationId, Is.EqualTo("S_LW"));
        }

        [Test]
        public void Frequencies_Then_the_frequencies_are_read()
        {
            // Assert
            Assert.That(_result.Frequencies, Has.Count.EqualTo(10));
        }

        [Test]
        public void Frequencies_Then_the_trip_id_is_read()
        {
            // Assert
            Assert.That(_result.Frequencies.Last().TripId, Is.EqualTo("TLSBWD"));
        }

        [Test]
        public void Frequencies_Then_the_start_time_is_read()
        {
            // Assert
            Assert.That(_result.Frequencies.Last().StartTime.TimeOfDay, Is.EqualTo(TimeSpan.Parse("20:00:00")));
        }

        [Test]
        public void Frequencies_Then_the_end_time_is_read()
        {
            // Assert
            Assert.That(_result.Frequencies.Last().EndTime.TimeOfDay, Is.EqualTo(TimeSpan.Parse("22:00:00")));
        }

        [Test]
        public void Frequencies_Then_the_headway_seconds_is_read()
        {
            // Assert
            Assert.That(_result.Frequencies.Last().HeadwaySeconds, Is.EqualTo(1440));
        }

        [Test]
        public void Routes_Then_the_routes_are_read()
        {
            // Assert
            Assert.That(_result.Routes, Has.Count.EqualTo(16));
        }

        [Test]
        public void Routes_Then_the_route_id_is_read()
        {
            // Assert
            Assert.That(_result.Routes.Any(f => string.IsNullOrEmpty(f.RouteId)), Is.False);
        }

        [Test]
        public void Routes_Then_the_route_short_name_is_read()
        {
            // Assert
            Assert.That(_result.Routes.Single(f => f.RouteId == "513S").RouteShortName, Is.EqualTo("513"));
        }

        [Test]
        public void Routes_Then_the_route_long_name_is_read()
        {
            // Assert
            Assert.That(_result.Routes.Single(f => f.RouteId == "513S").RouteLongName, Is.EqualTo("Everett - Seattle"));
        }

        [Test]
        public void Routes_Then_the_route_description_is_read()
        {
            // Assert
            Assert.That(_result.Routes.Single(f => f.RouteId == "513S").RouteDescription, Is.EqualTo("Sound Transit Route"));
        }

        [Test]
        public void Routes_Then_the_route_type_is_read()
        {
            // Assert
            Assert.That(_result.Routes.Single(f => f.RouteId == "513S").RouteType, Is.EqualTo(RouteType.Bus));
            Assert.That(_result.Routes.Single(f => f.RouteId == "TLINK").RouteType, Is.EqualTo(RouteType.LightRail));
            Assert.That(_result.Routes.Single(f => f.RouteId == "SNDR_N").RouteType, Is.EqualTo(RouteType.Rail));
        }

        [Test]
        public void Shapes_Then_the_shapes_are_read()
        {
            // Assert
            Assert.That(_result.Shapes, Has.Count.EqualTo(4115));
        }

        [Test]
        public void Shapes_Then_the_shape_id_is_read()
        {
            // Assert
            Assert.That(_result.Shapes.Any(f => string.IsNullOrEmpty(f.ShapeId)), Is.False);
        }

        [Test]
        public void Shapes_Then_the_shape_latitude_is_read()
        {
            // Assert
            Assert.That(_result.Shapes.First().ShapePointLatitude, Is.EqualTo(47.59756239));
        }

        [Test]
        public void Shapes_Then_the_shape_longitude_is_read()
        {
            // Assert
            Assert.That(_result.Shapes.First().ShapePointLongitude, Is.EqualTo(-122.3295129));
        }

        [Test]
        public void Shapes_Then_the_shape_sequence_is_read()
        {
            // Assert
            Assert.That(_result.Shapes.First().ShapePointSequence, Is.EqualTo(1));
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