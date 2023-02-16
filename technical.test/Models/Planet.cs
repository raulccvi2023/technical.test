using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical.test.Models
{
    public class Planet
    {
        public string climate { get; set; }
        public string diameter { get; set; }
        public string gravity { get; set; }
        public string name { get; set; }
        public string population { get; set; }
        //public string residents { get; set; }
        public string terrain { get; set; }
        public string url { get; set; }
        public int id { get; set; }
    }


    public class ListPlanet
    {
        public List<Planet> results { get; set; }
    }
}
