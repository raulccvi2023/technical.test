using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using technical.test.Models;

namespace technical.test.Services
{
    public class SwapiService
    {
        public List<People> listPeople(int? limit)
        {
            RestClient rc = new RestClient("https://swapi.dev/api/");
            RestRequest request = new RestRequest("people", Method.Get);
           
            RestResponse response = rc.Execute(request);

            var result = JsonConvert.DeserializeObject<ListPeople>(response.Content);

            if (limit == null)
                return result.results;
            else
                return result.results.GetRange(0, (int)limit);
        }

        public People getPeople(int id)
        {
            RestClient rc = new RestClient("https://swapi.dev/api/");
            RestRequest request = new RestRequest("people/" + id, Method.Get);

            RestResponse response = rc.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<People>(response.Content);

            return null;
        }

        public List<Planet> listPlanet(int? limit)
        {
            RestClient rc = new RestClient("https://swapi.dev/api/");
            RestRequest request = new RestRequest("planets", Method.Get);

            RestResponse response = rc.Execute(request);

            var result = JsonConvert.DeserializeObject<ListPlanet>(response.Content);

            if (limit == null)
                return result.results;
            else
                return result.results.GetRange(0, (int)limit);
        }

        public Planet getPlanet(int id)
        {
            RestClient rc = new RestClient("https://swapi.dev/api/");
            RestRequest request = new RestRequest("planets/" + id, Method.Get);

            RestResponse response = rc.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Planet>(response.Content);

            return null;
        }
    }
}
