using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{

    public class USMenuGenerator : MenuGenerator, IMenuGenerator
    {
        public static string US = "US";
        public USMenuGenerator(List<MenuItem> menuItems)
            : base(menuItems)
        {
        }

        public List<MenuItem> GetDinerItems()
        {
            return this.MenuItems.Where(i => i.Country == USMenuGenerator.US &&
                (i.Category == "Breakfast" ||
                i.Category == "Lunch" ||
                i.Category == "Snack" ||
                i.Category == "Appetizer" ||
                i.Category == "Dessert")).ToList();
        }

        public List<MenuItem> GetAllDayItems()
        {
            return this.MenuItems.Where(i => i.Country == USMenuGenerator.US &&
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
            return this.MenuItems.Where(i => i.Country == USMenuGenerator.US &&
                (i.Category == "Dinner" ||
                i.Category == "Side Dish" ||
                i.Category == "Appetizer" ||
                i.Category == "Dessert")).ToList();
        }
    }
}