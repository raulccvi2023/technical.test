using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical.test.Models;

namespace technical.test.Services
{
    public interface IGeneralService
    {
        List<People> ListPeople(int? limit);
        People GetPeople(int id);
        List<Planet> ListPlanet(int? limit);
        Planet GetPlanet(int id);

    }
}
