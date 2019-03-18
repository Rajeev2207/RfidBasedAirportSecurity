using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RfidBasedAirportSecurity.Models;

namespace RfidBasedAirportSecurity.Controllers
{
    public class PassengerDetailsController : ApiController
    {
        private RfidBasedAirportSecurityContext db = new RfidBasedAirportSecurityContext();

        // GET: api/PassengerDetails
        public IQueryable<PassengerDetails> GetPassengerDetails()
        {
            return db.PassengerDetails;
        }

        // GET: api/PassengerDetails/5
        [ResponseType(typeof(PassengerDetails))]
        public async Task<IHttpActionResult> GetPassengerDetails(string id)
        {
            PassengerDetails passengerDetails = await db.PassengerDetails.FindAsync(id);
            if (passengerDetails == null)
            {
                return NotFound();
            }

            return Ok(passengerDetails);
        }

        // PUT: api/PassengerDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPassengerDetails(string id, PassengerDetails passengerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passengerDetails.PassengerId)
            {
                return BadRequest();
            }

            db.Entry(passengerDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerDetailsExists(id))
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

        // POST: api/PassengerDetails
        [ResponseType(typeof(PassengerDetails))]
        public async Task<IHttpActionResult> PostPassengerDetails(PassengerDetails passengerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PassengerDetails.Add(passengerDetails);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassengerDetailsExists(passengerDetails.PassengerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = passengerDetails.PassengerId }, passengerDetails);
        }

        // DELETE: api/PassengerDetails/5
        [ResponseType(typeof(PassengerDetails))]
        public async Task<IHttpActionResult> DeletePassengerDetails(string id)
        {
            PassengerDetails passengerDetails = await db.PassengerDetails.FindAsync(id);
            if (passengerDetails == null)
            {
                return NotFound();
            }

            db.PassengerDetails.Remove(passengerDetails);
            await db.SaveChangesAsync();

            return Ok(passengerDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassengerDetailsExists(string id)
        {
            return db.PassengerDetails.Count(e => e.PassengerId == id) > 0;
        }
    }
}