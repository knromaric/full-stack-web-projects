using CoffeeRoomApi.Models;
using System.Data.Entity;

namespace CoffeeRoomApi.Data
{
    public class CoffeeRoomDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}