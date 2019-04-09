﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeRoomApi.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<SubMenu> SubMenus { get; set; }
    }
}