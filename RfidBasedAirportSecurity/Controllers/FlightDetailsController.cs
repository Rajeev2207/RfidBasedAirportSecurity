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
    public class FlightDetailsController : ApiController
    {
        private RfidBasedAirportSecurityContext db = new RfidBasedAirportSecurityContext();

        // GET: api/FlightDetails
        public IQueryable<FlightDetails> GetFlightDetails()
        {
            return db.FlightDetails;
        }

        // GET: api/FlightDetails/5
        [ResponseType(typeof(FlightDetails))]
        public async Task<IHttpActionResult> GetFlightDetails(string id)
        {
            FlightDetails flightDetails = await db.FlightDetails.FindAsync(id);
            if (flightDetails == null)
            {
                return NotFound();
            }

            return Ok(flightDetails);
        }

        // PUT: api/FlightDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlightDetails(string id, FlightDetails flightDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightDetails.Flight_Id)
            {
                return BadRequest();
            }

            db.Entry(flightDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailsExists(id))
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

        // POST: api/FlightDetails
        [ResponseType(typeof(FlightDetails))]
        public async Task<IHttpActionResult> PostFlightDetails(FlightDetails flightDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightDetails.Add(flightDetails);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightDetailsExists(flightDetails.Flight_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flightDetails.Flight_Id }, flightDetails);
        }

        // DELETE: api/FlightDetails/5
        [ResponseType(typeof(FlightDetails))]
        public async Task<IHttpActionResult> DeleteFlightDetails(string id)
        {
            FlightDetails flightDetails = await db.FlightDetails.FindAsync(id);
            if (flightDetails == null)
            {
                return NotFound();
            }

            db.FlightDetails.Remove(flightDetails);
            await db.SaveChangesAsync();

            return Ok(flightDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightDetailsExists(string id)
        {
            return db.FlightDetails.Count(e => e.Flight_Id == id) > 0;
        }
    }
}