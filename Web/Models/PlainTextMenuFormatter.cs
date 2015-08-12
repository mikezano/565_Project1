using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{

    public class PlainTextMenuFormatter : IMenuFormatter
    {
        public byte[] GetDownloadBytes(List<MenuItem> menuItems)
        {

            string result = string.Empty;
            foreach (var category in Enum.GetValues(typeof(CategoryOrder)))
            {
                var relevantItems = menuItems.Where(i => i.Category == MenuFormatter.GetCategory((CategoryOrder)category));
                if (relevantItems.Count() == 0) continue;

                result += category.ToString() + "\r\n";
                foreach (var item in relevantItems)
                {
                    result += item.Name + " (" + (item.Country == "US" ? "$" : "£") + item.Price + ")" + "\r\n";
                    result += item.Description + "\r\n";
                }

                result += "\r\n";
            }
            return System.Text.Encoding.ASCII.GetBytes(result);
        }
    }
}