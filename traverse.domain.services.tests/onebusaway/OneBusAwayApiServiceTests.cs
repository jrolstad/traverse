using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RestSharp;
using traverse.domain.services.onebusaway;

namespace traverse.domain.services.tests.onebusaway
{
    [TestFixture]
    [Category("External_Resource")]
    public class OneBusAwayApiServiceTests
    {
        private OneBusAwayApiService _service;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            const string key = "TEST";
            var client = new RestClient("http://api.onebusaway.org/");
            _service = new OneBusAwayApiService(client, key);
        }

        [Test]
        public void When_getting_agencies_with_coverage_then_they_are_obtained()
        {
            // Act
            var result = _service.AgencyWithCoverage();

            // Assert
            Assert.That(result,Is.Not.Null);
        }

        [Test]
        public void When_getting_an_agency_then_it_is_obtained()
        {
            // Act
            var result = _service.Agency("1");

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_getting_arrival_and_departure_then_it_is_obtained()
        {
            // Act
            var result = _service.ArrivalAndDepartureForStop("1_75403", "1_15551341", 1291536000000);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_getting_arrivals_and_departures_then_it_is_obtained()
        {
            // Act
            var result = _service.ArrivalsAndDeparturesForStop("1_75403");

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_getting_current_time_then_it_is_obtained()
        {
            // Act
            var result = _service.CurrentTime();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_route_ids_for_agencies_then_it_is_obtained()
        {
            // Act
            var result = _service.RouteIdsForAgency("40");

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_route_then_it_is_obtained()
        {
            // Act
            var result = _service.Route("40");

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_routes_for_agency_then_it_is_obtained()
        {
            // Act
            var result = _service.RoutesForAgency("1");

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void When_routes_for_location_then_it_is_obtained()
        {
            // Act
            var result = _service.RoutesForLocation(47.653435m, -122.305641m);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Routes, Is.Not.Null);
        }

        [Test]
        public void When_routes_for_location_and_route_name_then_it_is_obtained()
        {
            // Act
            var result = _service.RoutesForLocation(47.653435m, -122.305641m,routeShortName:"40");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Routes, Is.Not.Null);
        }

        [Test]
        public void When_getting_schedule_for_stop_then_it_is_obtained()
        {
            // Act
            var result = _service.ScheduleForStop("1_75403");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Entry, Is.Not.Null);
            Assert.That(result.Data.Entry.StopRouteSchedules, Is.Not.Null);
            Assert.That(result.Data.Entry.StopRouteSchedules.All(s=>s.StopRouteDirectionSchedules!=null), Is.True);
            Assert.That(result.Data.Entry.StopRouteSchedules.All(s=>s.StopRouteDirectionSchedules.All(r=>r.ScheduleStopTimes!=null)),Is.True);
        }

        [Test]
        public void When_getting_stop_ids_for_agency_then_it_is_obtained()
        {
            // Act
            var result = _service.StopIdsForAgency("1");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.List, Is.Not.Null);
            Assert.That(result.Data.List, Is.Not.Null);
        }

        [Test]
        public void When_getting_stop_then_it_is_obtained()
        {
            // Act
            var result = _service.Stop("1_75403");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Routes, Is.Not.Null);
        }

        [Test]
        public void When_getting_stops_for_location_then_it_is_obtained()
        {
            // Act
            var result = _service.StopsForLocation(47.653435m, -122.305641m);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Stops, Is.Not.Null);
        }

        [Test]
        public void When_getting_stops_for_location_and_stop_then_it_is_obtained()
        {
            // Act
            var result = _service.StopsForLocation(47.653435m, -122.305641m, stopCode: "10917");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Stops, Is.Not.Null);
            Assert.That(result.Data.Stops.Count,Is.EqualTo(1));
        }

    }
}