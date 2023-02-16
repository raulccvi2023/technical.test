using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using technical.test.Models;

namespace technical.test.Repository
{
    public class PlanetRepository : BaseRepository
    {
        public Planet get(int id)
        {
            Planet entity = null;
            using (SqlConnection conn = new SqlConnection(base.getConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("select * from planet where id = " + id, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    entity = new Planet();

                    int iId = dr.GetOrdinal("id");
                    if (!dr.IsDBNull(iId)) entity.id = dr.GetInt32(iId);

                    int iClimate = dr.GetOrdinal("climate");
                    if (!dr.IsDBNull(iClimate)) entity.climate = dr.GetString(iClimate);

                    int iDiameter = dr.GetOrdinal("diameter");
                    if (!dr.IsDBNull(iDiameter)) entity.diameter = dr.GetString(iDiameter);

                    int iGravity = dr.GetOrdinal("gravity");
                    if (!dr.IsDBNull(iGravity)) entity.gravity = dr.GetString(iGravity);

                    int iName = dr.GetOrdinal("name");
                    if (!dr.IsDBNull(iName)) entity.name = dr.GetString(iName);

                    int iPopulation = dr.GetOrdinal("population");
                    if (!dr.IsDBNull(iPopulation)) entity.population = dr.GetString(iPopulation);

                    //int iResidents = dr.GetOrdinal("residents");
                    //if (!dr.IsDBNull(iResidents)) entity.residents = dr.GetString(iResidents);

                    int iTerrain = dr.GetOrdinal("terrain");
                    if (!dr.IsDBNull(iTerrain)) entity.terrain = dr.GetString(iTerrain);

                    int iUrl = dr.GetOrdinal("url");
                    if (!dr.IsDBNull(iUrl)) entity.url = dr.GetString(iUrl);
                }
            }

            return entity;
        }


        public void save(Planet entity)
        {
            using (SqlConnection conn = new SqlConnection(base.getConnectionString()))
            {
                string query = string.Format(@"insert into planet
                                (id ,climate ,diameter,gravity,name,population,residents,terrain,url)
                                values ({0} ,'{1}' ,'{1}' ,'{1}' ,'{1}' ,'{1}' ,'{1}' ,'{1}' ,'{1}')",
                                entity.id, entity.climate, entity.diameter, entity.gravity, entity.name,
                                entity.population, string.Empty, entity.terrain, entity.url);
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
            }


        }
    }
}
