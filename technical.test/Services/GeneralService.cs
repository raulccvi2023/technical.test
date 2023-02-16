using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technical.test.Models;
using technical.test.Repository;

namespace technical.test.Services
{
    public class GeneralService
    {
        SwapiService swapiService = new SwapiService();

        private readonly ILogger<GeneralService> _logger;
        public GeneralService()
        {
            using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
            .SetMinimumLevel(LogLevel.Trace)
            .AddConsole());
            _logger = loggerFactory.CreateLogger<GeneralService>();
        }

        public List<People> ListPeople(int? limit)
        {
            try
            {
                return this.swapiService.listPeople(limit);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error ocurred.");
                throw new Exception(ex.Message, ex);
            }
        }

        public People GetPeople(int id)
        {
            try
            {
                People entity = (new PeopleRepository()).get(id);

                if (entity == null)
                {
                    entity = this.swapiService.getPeople(id);

                    if (entity != null)
                    {
                        entity.id = id;
                        (new PeopleRepository()).save(entity);
                    }
                }

                return entity;

            }
            catch (Exception ex)
            {
                _logger.LogError("An error ocurred.");
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Planet> ListPlanet(int? limit)
        {
            try
            {
                return this.swapiService.listPlanet(limit);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error ocurred.");
                throw new Exception(ex.Message, ex);
            }
        }

        public Planet GetPlanet(int id)
        {
            try
            {
                Planet entity = (new PlanetRepository()).get(id);

                if (entity == null)
                {
                    entity = this.swapiService.getPlanet(id);

                    if (entity != null)
                    {
                        entity.id = id;
                        (new PlanetRepository()).save(entity);
                    }
                }

                return entity;

            }
            catch (Exception ex)
            {
                _logger.LogError("An error ocurred.");
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
