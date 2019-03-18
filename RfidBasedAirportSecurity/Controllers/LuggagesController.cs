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
    public class LuggagesController : ApiController
    {
        private RfidBasedAirportSecurityContext db = new RfidBasedAirportSecurityContext();

        // GET: api/Luggages
        public IQueryable<Luggage> GetLuggages()
        {
            return db.Luggages;
        }

        // GET: api/Luggages/5
        [ResponseType(typeof(Luggage))]
        public async Task<IHttpActionResult> GetLuggage(string id)
        {
            Luggage luggage = await db.Luggages.FindAsync(id);
            if (luggage == null)
            {
                return NotFound();
            }

            return Ok(luggage);
        }

        // PUT: api/Luggages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLuggage(string id, Luggage luggage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != luggage.Luggage_RFID_Id)
            {
                return BadRequest();
            }

            db.Entry(luggage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuggageExists(id))
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

        // POST: api/Luggages
        [ResponseType(typeof(Luggage))]
        public async Task<IHttpActionResult> PostLuggage(Luggage luggage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Luggages.Add(luggage);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LuggageExists(luggage.Luggage_RFID_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = luggage.Luggage_RFID_Id }, luggage);
        }

        // DELETE: api/Luggages/5
        [ResponseType(typeof(Luggage))]
        public async Task<IHttpActionResult> DeleteLuggage(string id)
        {
            Luggage luggage = await db.Luggages.FindAsync(id);
            if (luggage == null)
            {
                return NotFound();
            }

            db.Luggages.Remove(luggage);
            await db.SaveChangesAsync();

            return Ok(luggage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LuggageExists(string id)
        {
            return db.Luggages.Count(e => e.Luggage_RFID_Id == id) > 0;
        }
    }
}