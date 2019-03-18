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
    public class RfidInventoriesController : ApiController
    {
        private RfidBasedAirportSecurityContext db = new RfidBasedAirportSecurityContext();

        // GET: api/RfidInventories
        public IQueryable<RfidInventory> GetRfidInventories()
        {
            return db.RfidInventories;
        }

        // GET: api/RfidInventories/5
        [ResponseType(typeof(RfidInventory))]
        public async Task<IHttpActionResult> GetRfidInventory(string id)
        {
            RfidInventory rfidInventory = await db.RfidInventories.FindAsync(id);
            if (rfidInventory == null)
            {
                return NotFound();
            }

            return Ok(rfidInventory);
        }

        // PUT: api/RfidInventories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRfidInventory(string id, RfidInventory rfidInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rfidInventory.RFID_ID)
            {
                return BadRequest();
            }

            db.Entry(rfidInventory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RfidInventoryExists(id))
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

        // POST: api/RfidInventories
        [ResponseType(typeof(RfidInventory))]
        public async Task<IHttpActionResult> PostRfidInventory(RfidInventory rfidInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RfidInventories.Add(rfidInventory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RfidInventoryExists(rfidInventory.RFID_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rfidInventory.RFID_ID }, rfidInventory);
        }

        // DELETE: api/RfidInventories/5
        [ResponseType(typeof(RfidInventory))]
        public async Task<IHttpActionResult> DeleteRfidInventory(string id)
        {
            RfidInventory rfidInventory = await db.RfidInventories.FindAsync(id);
            if (rfidInventory == null)
            {
                return NotFound();
            }

            db.RfidInventories.Remove(rfidInventory);
            await db.SaveChangesAsync();

            return Ok(rfidInventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RfidInventoryExists(string id)
        {
            return db.RfidInventories.Count(e => e.RFID_ID == id) > 0;
        }
    }
}