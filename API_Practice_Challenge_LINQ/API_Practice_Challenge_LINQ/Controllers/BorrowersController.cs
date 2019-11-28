﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Practice_Challenge_LINQ.Models;

namespace API_Practice_Challenge_LINQ.Controllers
{
    public class BorrowersController : ApiController
    {
        private civapiEntities db = new civapiEntities();

        // GET: api/Borrowers
        public IQueryable<Borrower> GetBorrowers()
        {
            return db.Borrowers;
        }

        // GET: api/Borrowers/5
        [ResponseType(typeof(Borrower))]
        public IHttpActionResult GetBorrower(int id)
        {
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return NotFound();
            }

            return Ok(borrower);
        }

        // PUT: api/Borrowers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBorrower(int id, Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != borrower.id)
            {
                return BadRequest();
            }

            db.Entry(borrower).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Borrowers
        [ResponseType(typeof(Borrower))]
        public IHttpActionResult PostBorrower(Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Borrowers.Add(borrower);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BorrowerExists(borrower.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = borrower.id }, borrower);
        }

        // DELETE: api/Borrowers/5
        [ResponseType(typeof(Borrower))]
        public IHttpActionResult DeleteBorrower(int id)
        {
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return NotFound();
            }

            db.Borrowers.Remove(borrower);
            db.SaveChanges();

            return Ok(borrower);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BorrowerExists(int id)
        {
            return db.Borrowers.Count(e => e.id == id) > 0;
        }
    }
}