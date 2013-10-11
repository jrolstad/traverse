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