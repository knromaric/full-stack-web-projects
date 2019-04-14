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
using FlightAndHotelApi.Data;
using FlightAndHotelApi.Models;

namespace FlightAndHotelApi.Controllers
{
    public class FlightAndHotelsController : ApiController
    {
        private FlightAndHotelDbContext db = new FlightAndHotelDbContext();

        // GET: api/FlightAndHotels
        public IQueryable<FlightAndHotel> GetFlightAndHotels()
        {
            return db.FlightAndHotels;
        }

        // GET: api/FlightAndHotels/5
        [ResponseType(typeof(FlightAndHotel))]
        public async Task<IHttpActionResult> GetFlightAndHotel(int id)
        {
            FlightAndHotel flightAndHotel = await db.FlightAndHotels.FindAsync(id);
            if (flightAndHotel == null)
            {
                return NotFound();
            }

            return Ok(flightAndHotel);
        }

        // PUT: api/FlightAndHotels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlightAndHotel(int id, FlightAndHotel flightAndHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightAndHotel.ID)
            {
                return BadRequest();
            }

            db.Entry(flightAndHotel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightAndHotelExists(id))
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

        // POST: api/FlightAndHotels
        [ResponseType(typeof(FlightAndHotel))]
        public async Task<IHttpActionResult> PostFlightAndHotel(FlightAndHotel flightAndHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightAndHotels.Add(flightAndHotel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = flightAndHotel.ID }, flightAndHotel);
        }

        // DELETE: api/FlightAndHotels/5
        [ResponseType(typeof(FlightAndHotel))]
        public async Task<IHttpActionResult> DeleteFlightAndHotel(int id)
        {
            FlightAndHotel flightAndHotel = await db.FlightAndHotels.FindAsync(id);
            if (flightAndHotel == null)
            {
                return NotFound();
            }

            db.FlightAndHotels.Remove(flightAndHotel);
            await db.SaveChangesAsync();

            return Ok(flightAndHotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightAndHotelExists(int id)
        {
            return db.FlightAndHotels.Count(e => e.ID == id) > 0;
        }
    }
}