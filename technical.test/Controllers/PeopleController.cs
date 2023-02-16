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
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        GeneralService service = new GeneralService();

        /// <summary>
        /// API: List people with a limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet()]
        public IList<People> ListPeople(int? limit)
        {
            return this.service.ListPeople(limit);
        }

        /// <summary>
        /// API: Get people by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public People GetPeople(int id)
        {
            People entity =  this.service.GetPeople(id);
            if (entity == null){
                this.HttpContext.Response.StatusCode = 404;
            }
            return entity;
        }
    }
}
