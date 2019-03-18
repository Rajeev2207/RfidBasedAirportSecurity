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
    public class PassengerAreaAccessesController : ApiController
    {
        private RfidBasedAirportSecurityContext db = new RfidBasedAirportSecurityContext();

        // GET: api/PassengerAreaAccesses
        public IQueryable<PassengerAreaAccess> GetPassengerAreaAccesses()
        {
            return db.PassengerAreaAccesses;
        }

        // GET: api/PassengerAreaAccesses/5
        [ResponseType(typeof(PassengerAreaAccess))]
        public async Task<IHttpActionResult> GetPassengerAreaAccess(string id)
        {
            PassengerAreaAccess passengerAreaAccess = await db.PassengerAreaAccesses.FindAsync(id);
            if (passengerAreaAccess == null)
            {
                return NotFound();
            }

            return Ok(passengerAreaAccess);
        }

        // PUT: api/PassengerAreaAccesses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPassengerAreaAccess(string id, PassengerAreaAccess passengerAreaAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passengerAreaAccess.ZoneId)
            {
                return BadRequest();
            }

            db.Entry(passengerAreaAccess).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerAreaAccessExists(id))
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

        // POST: api/PassengerAreaAccesses
        [ResponseType(typeof(PassengerAreaAccess))]
        public async Task<IHttpActionResult> PostPassengerAreaAccess(PassengerAreaAccess passengerAreaAccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PassengerAreaAccesses.Add(passengerAreaAccess);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassengerAreaAccessExists(passengerAreaAccess.ZoneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = passengerAreaAccess.ZoneId }, passengerAreaAccess);
        }

        // DELETE: api/PassengerAreaAccesses/5
        [ResponseType(typeof(PassengerAreaAccess))]
        public async Task<IHttpActionResult> DeletePassengerAreaAccess(string id)
        {
            PassengerAreaAccess passengerAreaAccess = await db.PassengerAreaAccesses.FindAsync(id);
            if (passengerAreaAccess == null)
            {
                return NotFound();
            }

            db.PassengerAreaAccesses.Remove(passengerAreaAccess);
            await db.SaveChangesAsync();

            return Ok(passengerAreaAccess);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassengerAreaAccessExists(string id)
        {
            return db.PassengerAreaAccesses.Count(e => e.ZoneId == id) > 0;
        }
    }
}