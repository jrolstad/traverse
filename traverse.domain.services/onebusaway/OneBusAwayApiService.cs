using System;
using System.Collections.Generic;
using RestSharp;
using traverse.onebusaway.models;

namespace traverse.domain.services.onebusaway
{
    public class OneBusAwayApiService
    {
        private readonly IRestClient _restClient;
        private readonly string _applicationKey;

        public OneBusAwayApiService(IRestClient restClient, string applicationKey)
        {
            _restClient = restClient;
            _applicationKey = applicationKey;
        }

        public OneBusAwayResponse<List<AgencyWithCoverage>> AgencyWithCoverage()
        {
            var request = new RestRequest("api/where/agencies-with-coverage.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<List<AgencyWithCoverage>>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayDataEntry<Agency>> Agency(string agencyId)
        {
            var request = new RestRequest("api/where/agency/{AgencyId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("AgencyId", agencyId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayDataEntry<Agency>>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayDataEntry<ArrivalAndDeparture>> ArrivalAndDepartureForStop(string stopId,string tripId, long serviceDate)
        {
            var request = new RestRequest("api/where/arrival-and-departure-for-stop/{StopId}.json?key={ApplicationKey}&tripId={TripId}&serviceDate={ServiceDate}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("StopId", stopId, ParameterType.UrlSegment);
            request.AddParameter("TripId", tripId, ParameterType.UrlSegment);
            request.AddParameter("ServiceDate", serviceDate, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayDataEntry<ArrivalAndDeparture>>>(request);

            return response;
        }

        public OneBusAwayResponse<StopWithArrivalsAndDepartures> ArrivalsAndDeparturesForStop(string stopId)
        {
            var request = new RestRequest("api/where/arrivals-and-departures-for-stop/{StopId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("StopId", stopId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<StopWithArrivalsAndDepartures>>(request);

            return response;
        }

        public OneBusAwayResponse<CurrentTime> CurrentTime()
        {
            var request = new RestRequest("api/where/current-time.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<CurrentTime>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayList<string>> RouteIdsForAgency(string agencyId)
        {
            var request = new RestRequest("api/where/route-ids-for-agency/{AgencyId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("AgencyId", agencyId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayList<string>>>(request);

            return response;
        }

        public OneBusAwayResponse<Route> Route(string routeId)
        {
            var request = new RestRequest("api/where/route/{RouteId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("RouteId", routeId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<Route>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayList<Route>> RoutesForAgency(string agencyId)
        {
            var request = new RestRequest("api/where/routes-for-agency/{AgencyId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("AgencyId", agencyId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayList<Route>>>(request);

            return response;
        }

        public OneBusAwayResponse<RouteList> RoutesForLocation(decimal latitude, decimal longitude, decimal? radius = null, decimal? latitudeSpan = null, decimal? longitudeSpan = null, string routeShortName = null)
        {
            var request = new RestRequest("api/where/routes-for-location.json");
            request.AddParameter("key", _applicationKey, ParameterType.GetOrPost);
            request.AddParameter("lat", latitude, ParameterType.GetOrPost);
            request.AddParameter("lon", longitude, ParameterType.GetOrPost);

            if (radius.HasValue)
            {
                request.AddParameter("Radius", radius, ParameterType.GetOrPost);
            }

            if (latitudeSpan.HasValue && longitudeSpan.HasValue)
            {
                request.AddParameter("latSpan", latitudeSpan, ParameterType.GetOrPost);
                request.AddParameter("lonSpan", longitudeSpan, ParameterType.GetOrPost);
            }

            if (!string.IsNullOrWhiteSpace(routeShortName))
            {
                request.AddParameter("query", routeShortName, ParameterType.GetOrPost);
            }

            var response = ExecuteRequest<OneBusAwayResponse<RouteList>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayDataEntry<StopRouteScheduleSet>> ScheduleForStop(string stopId)
        {
            var request = new RestRequest("api/where/schedule-for-stop/{StopId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("StopId", stopId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayDataEntry<StopRouteScheduleSet>>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayList<string>> StopIdsForAgency(string agencyId)
        {
            var request = new RestRequest("api/where/stop-ids-for-agency/{AgencyId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("AgencyId", agencyId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayList<string>>>(request);

            return response;
        }

        public OneBusAwayResponse<Stop> Stop(string stopId)
        {
            var request = new RestRequest("api/where/stop/{StopId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("StopId", stopId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<Stop>>(request);

            return response;
        }

        public OneBusAwayResponse<StopList> StopsForLocation(decimal latitude, decimal longitude, decimal? radius = null, decimal? latitudeSpan = null, decimal? longitudeSpan = null, string stopCode = null)
        {
            var request = new RestRequest("api/where/stops-for-location.json");
            request.AddParameter("key", _applicationKey, ParameterType.GetOrPost);
            request.AddParameter("lat", latitude, ParameterType.GetOrPost);
            request.AddParameter("lon", longitude, ParameterType.GetOrPost);

            if (radius.HasValue)
            {
                request.AddParameter("Radius", radius, ParameterType.GetOrPost);
            }

            if (latitudeSpan.HasValue && longitudeSpan.HasValue)
            {
                request.AddParameter("LatSpan", latitudeSpan, ParameterType.GetOrPost);
                request.AddParameter("LonSpan", longitudeSpan, ParameterType.GetOrPost);
            }

            if (!string.IsNullOrWhiteSpace(stopCode))
            {
                request.AddParameter("query", stopCode, ParameterType.GetOrPost);
            }

            var response = ExecuteRequest<OneBusAwayResponse<StopList>>(request);

            return response;
        }

        public OneBusAwayResponse<OneBusAwayList<string>> StopsForRoute(string routeId)
        {
            var request = new RestRequest("api/where/stops-for-route/{RouteId}.json?key={ApplicationKey}");
            request.AddParameter("ApplicationKey", _applicationKey, ParameterType.UrlSegment);
            request.AddParameter("RouteId", routeId, ParameterType.UrlSegment);

            var response = ExecuteRequest<OneBusAwayResponse<OneBusAwayList<string>>>(request);

            return response;
        }

        private T ExecuteRequest<T>(IRestRequest request) where T : new()
        {
            var response = _restClient.Execute<T>(request);

            if (response.ErrorException != null)
            {
                var message = string.Format("Error retrieving response from '{0}'.  Check inner details for more info.",response.ResponseUri);
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }
            return response.Data;
        }

    }
}