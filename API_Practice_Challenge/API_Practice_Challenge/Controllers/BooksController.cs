using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using API_Practice_Challenge.Models;

namespace API_Practice_Challenge.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IEnumerable<Books> Get()
        {
            SqlConnection conn = new SqlConnection("Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330;");
            conn.Open();

            SqlCommand getBooks = new SqlCommand("SELECT B.ISBN, B.TITLE, BORROWER.ID, BORROWER.SURNAME, BORROWER.FIRSTNAME, BORROWER.DOB, AUTHOR.ID," +
                "AUTHOR.FIRSTNAME, AUTHOR.SURNAME " +
                "FROM BOOKS B " +
                "INNER JOIN BORROWER ON B.BORROWER = BORROWER.ID " +
                "INNER JOIN AUTHOR ON B.AUTHOR = AUTHOR.ID", conn);

            SqlDataReader booksReader = getBooks.ExecuteReader();

            List<Books> listOfBooks = new List<Books>(); 

            while (booksReader.Read())
            {
                listOfBooks.Add(new Books(int.Parse(booksReader[0].ToString()), 
                    booksReader[1].ToString(), new Borrower(int.Parse(booksReader[2].ToString()), booksReader[3].ToString(), 
                    booksReader[4].ToString(), booksReader[4].ToString()),
                    new Author(int.Parse(booksReader[5].ToString()), booksReader[6].ToString(),
                    booksReader[7].ToString())));
            }
            conn.Close();
            return listOfBooks;
        }

        // GET: api/Books/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Books
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
