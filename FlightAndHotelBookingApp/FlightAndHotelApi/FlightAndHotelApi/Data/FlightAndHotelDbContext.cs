using FlightAndHotelApi.Models;
using System.Data.Entity;

namespace FlightAndHotelApi.Data
{
    public class FlightAndHotelDbContext:DbContext
    {
        public DbSet<FlightAndHotel> FlightAndHotels { get; set; }
    }
}