using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Practice_Challenge.Models
{
    public class Author
    {
        public int ID;
        public string FirstName;
        public string Surname;

        public Author(int id, string firstname, string surname)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.Surname = surname;
        }
    }
}