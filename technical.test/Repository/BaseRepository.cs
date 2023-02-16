using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technical.test.Repository
{
    public class BaseRepository
    {
        public string getConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

            return config.GetConnectionString("Default");
        }
        
    }
}
