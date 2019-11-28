using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Practice_Challenge.Models;
using System.Data.SqlClient;

namespace API_Practice_Challenge.Controllers
{
    public class AuthorsController : ApiController
    {
        // GET: api/Authors
        public IEnumerable<Author> Get()
        {
            List<Author> listOfAuthors = new List<Author>();

            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();
            SqlCommand getAuthors = new SqlCommand("SELECT * FROM AUTHOR", conn);

            SqlDataReader reader = getAuthors.ExecuteReader();

            while(reader.Read())
            {
                listOfAuthors.Add(new Author(int.Parse(reader[0].ToString()), 
                    reader[1].ToString(), reader[2].ToString()));
            }

            conn.Close();

            return listOfAuthors;
        }

        // GET: api/Authors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Authors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Authors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
        }
    }
}
