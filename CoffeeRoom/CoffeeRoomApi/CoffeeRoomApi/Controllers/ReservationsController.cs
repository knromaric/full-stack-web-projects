using CoffeeRoomApi.Data;
using CoffeeRoomApi.Models;
using System.Net;
using System.Web.Http;

namespace CoffeeRoomApi.Controllers
{
    public class ReservationsController : ApiController
    {
        private CoffeeRoomDbContext _dbContext = new CoffeeRoomDbContext();
        
        [HttpPost]
        public IHttpActionResult CreateReservation([FromBody]Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

            return StatusCode(HttpStatusCode.Created);
        }
    }
}
