using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class GBMenuGenerator : MenuGenerator, IMenuGenerator
    {
        public static string GB = "GB";
        public GBMenuGenerator(List<MenuItem> menuItems)
            : base(menuItems)
        {
        }

        public List<MenuItem> GetDinerItems()
        {
            return this.MenuItems.Where(i => i.Country == GBMenuGenerator.GB &&
                (i.Category == "Breakfast" ||
                i.Category == "Lunch" ||
                i.Category == "Snack" ||
                i.Category == "Appetizer" ||
                i.Category == "Dessert")).ToList();
        }

        public List<MenuItem> GetAllDayItems()
        {
            return this.MenuItems.Where(i => i.Country == GBMenuGenerator.GB &&
                (i.Category == "Breakfast" ||
                i.Category == "Lunch" ||
                i.Category == "Snack" ||
                i.Category == "Side Dish" ||
                i.Category == "Appetizer" ||
                i.Category == "Dinner" ||
                i.Category == "Dessert"
                )).ToList();
        }

        public List<MenuItem> GetEveningOnlyItems()
        {
            return this.MenuItems.Where(i => i.Country == GBMenuGenerator.GB &&
                (i.Category == "Dinner" ||
                i.Category == "Side Dish" ||
                i.Category == "Appetizer" ||
                i.Category == "Dessert")).ToList();
        }
    }
}