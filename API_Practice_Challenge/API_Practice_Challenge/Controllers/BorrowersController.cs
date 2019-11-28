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
    public class BorrowersController : ApiController
    {
        // GET: api/Borrowers
        public IEnumerable<Borrower> Get()
        {
            List<Borrower> listOfBorrowers = new List<Borrower>();

            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");

            conn.Open();
            SqlCommand getAuthors = new SqlCommand("SELECT * FROM BORROWER", conn);

            SqlDataReader reader = getAuthors.ExecuteReader();

            while (reader.Read())
            {
                listOfBorrowers.Add(new Borrower(int.Parse(reader[0].ToString()),
                    reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
            }

            conn.Close();
            return listOfBorrowers;
        }

        // GET: api/Borrowers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Borrowers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Borrowers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrowers/5
        public void Delete(int id)
        {
        }
    }
}
