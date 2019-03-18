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
    public class ZoneInfoMetaDatasController : ApiController
    {
        private RfidBasedAirportSecurityContext db = new RfidBasedAirportSecurityContext();

        // GET: api/ZoneInfoMetaDatas
        public IQueryable<ZoneInfoMetaData> GetZoneInfoMetaDatas()
        {
            return db.ZoneInfoMetaDatas;
        }

        // GET: api/ZoneInfoMetaDatas/5
        [ResponseType(typeof(ZoneInfoMetaData))]
        public async Task<IHttpActionResult> GetZoneInfoMetaData(string id)
        {
            ZoneInfoMetaData zoneInfoMetaData = await db.ZoneInfoMetaDatas.FindAsync(id);
            if (zoneInfoMetaData == null)
            {
                return NotFound();
            }

            return Ok(zoneInfoMetaData);
        }

        // PUT: api/ZoneInfoMetaDatas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZoneInfoMetaData(string id, ZoneInfoMetaData zoneInfoMetaData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zoneInfoMetaData.ZoneId)
            {
                return BadRequest();
            }

            db.Entry(zoneInfoMetaData).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneInfoMetaDataExists(id))
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

        // POST: api/ZoneInfoMetaDatas
        [ResponseType(typeof(ZoneInfoMetaData))]
        public async Task<IHttpActionResult> PostZoneInfoMetaData(ZoneInfoMetaData zoneInfoMetaData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZoneInfoMetaDatas.Add(zoneInfoMetaData);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZoneInfoMetaDataExists(zoneInfoMetaData.ZoneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zoneInfoMetaData.ZoneId }, zoneInfoMetaData);
        }

        // DELETE: api/ZoneInfoMetaDatas/5
        [ResponseType(typeof(ZoneInfoMetaData))]
        public async Task<IHttpActionResult> DeleteZoneInfoMetaData(string id)
        {
            ZoneInfoMetaData zoneInfoMetaData = await db.ZoneInfoMetaDatas.FindAsync(id);
            if (zoneInfoMetaData == null)
            {
                return NotFound();
            }

            db.ZoneInfoMetaDatas.Remove(zoneInfoMetaData);
            await db.SaveChangesAsync();

            return Ok(zoneInfoMetaData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZoneInfoMetaDataExists(string id)
        {
            return db.ZoneInfoMetaDatas.Count(e => e.ZoneId == id) > 0;
        }
    }
}