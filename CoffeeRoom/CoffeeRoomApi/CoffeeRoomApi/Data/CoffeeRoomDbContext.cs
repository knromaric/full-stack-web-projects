using CoffeeRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoffeeRoomApi.Data
{
    public class CoffeeRoomDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}