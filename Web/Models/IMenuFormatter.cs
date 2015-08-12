using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace Web.Models
{

    public interface IMenuFormatter
    {
        byte[] GetDownloadBytes(List<MenuItem> menuItems);
    }

    public enum CategoryOrder
    {
        Breakfast,
        Snack,
        Appetizer,
        Lunch,
        Dinner,
        Dessert,
        Side
    }

    public class MenuFormatter
    {
        public static string GetCategory(CategoryOrder category)
        {
            if (category == CategoryOrder.Side)
                return "Side Dish";
            return category.ToString();
        }
    }
}