using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using technical.test.Models;

namespace technical.test.Repository
{
    public class PeopleRepository : BaseRepository
    {
        public People get(int id)
        {
            People entity = null;
            using (SqlConnection conn = new SqlConnection(base.getConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("select * from people where id = " + id, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    entity = new People();

                    int iId = dr.GetOrdinal("id");
                    if (!dr.IsDBNull(iId)) entity.id = dr.GetInt32(iId);

                    int iName = dr.GetOrdinal("name");
                    if (!dr.IsDBNull(iName)) entity.name = dr.GetString(iName);

                    int iBirth_year = dr.GetOrdinal("birth_year");
                    if (!dr.IsDBNull(iBirth_year)) entity.birth_year = dr.GetString(iBirth_year);

                    int iEye_color = dr.GetOrdinal("eye_color");
                    if (!dr.IsDBNull(iEye_color)) entity.eye_color = dr.GetString(iEye_color);

                    int iGender = dr.GetOrdinal("gender");
                    if (!dr.IsDBNull(iGender)) entity.gender = dr.GetString(iGender);

                    int iHair_color = dr.GetOrdinal("hair_color");
                    if (!dr.IsDBNull(iHair_color)) entity.hair_color = dr.GetString(iHair_color);

                    int iHeight = dr.GetOrdinal("height");
                    if (!dr.IsDBNull(iHeight)) entity.height = dr.GetString(iHeight);

                    int iHomeworld = dr.GetOrdinal("homeworld");
                    if (!dr.IsDBNull(iHomeworld)) entity.homeworld = dr.GetString(iHomeworld);

                    int iMass = dr.GetOrdinal("mass");
                    if (!dr.IsDBNull(iMass)) entity.mass = dr.GetString(iMass);

                    int iSkin_color = dr.GetOrdinal("skin_color");
                    if (!dr.IsDBNull(iSkin_color)) entity.skin_color = dr.GetString(iSkin_color);

                    int iSreated = dr.GetOrdinal("created");
                    if (!dr.IsDBNull(iSreated)) entity.created = dr.GetString(iSreated);

                    int iEdited = dr.GetOrdinal("edited");
                    if (!dr.IsDBNull(iEdited)) entity.edited = dr.GetString(iEdited);

                    int iUrl = dr.GetOrdinal("url");
                    if (!dr.IsDBNull(iUrl)) entity.url = dr.GetString(iUrl);
                }
            }

            return entity;
        }

        public void save(People entity)
        {
            using (SqlConnection conn = new SqlConnection(base.getConnectionString()))
            {
                string query = string.Format(@"insert into people
                               (id, name, birth_year,eye_color,gender,hair_color,height,homeworld,mass,skin_color,created,edited,url)
                                values ({0} ,'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", 
                               entity.id,  entity.name, entity.birth_year, entity.eye_color,
                               entity.gender, entity.hair_color, entity.height, entity.homeworld,
                               entity.mass, entity.skin_color, entity.created, entity.edited, entity.url);
                
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
