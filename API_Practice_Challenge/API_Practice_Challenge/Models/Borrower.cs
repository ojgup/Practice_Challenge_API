using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Practice_Challenge.Models
{
    public class Borrower
    {
        public int ID;
        public string FirstName;
        public string LastName;
        public string Date;

        public Borrower(int id, string firstname, string lastname, string date)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Date = date;
        }
    }
}