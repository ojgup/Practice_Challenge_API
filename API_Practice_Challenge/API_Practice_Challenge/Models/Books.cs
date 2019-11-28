using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Practice_Challenge.Models
{
    public class Books
    {
        public int ISBN;
        public string Title;
        public Borrower Borrower;
        public Author Author;


        public Books(int isbn, string title, Borrower borrower, Author author)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Borrower = borrower;
            this.Author = author;
        }
    }
}