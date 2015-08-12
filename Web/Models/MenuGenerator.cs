using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class MenuGenerator
    {
        public List<MenuItem> MenuItems{get; set;}

        public MenuGenerator(List<MenuItem> menuItems){
            this.MenuItems = menuItems;
        }
    }

}