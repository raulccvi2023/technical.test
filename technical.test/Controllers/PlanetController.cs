using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using technical.test.Models;
using technical.test.Services;

namespace technical.test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        IGeneralService service;

        public PlanetController(IGeneralService service)
        {
            this.service = service;
        }

        /// <summary>
        /// API: List planetes
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet()]
        public IList<Planet> ListPlanets(int? limit)
        {
            return this.service.ListPlanet(limit);
        }

        /// <summary>
        /// API: Get planet by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Planet GetPlanets(int id)
        {            
            Planet entity = this.service.GetPlanet(id);
            if (entity == null)
            {
                this.HttpContext.Response.StatusCode = 404;
            }
            return entity;
        }
    }
}
