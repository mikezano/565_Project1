using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Web.Models
{
    public class JsonMenuReader : IMenuReader
    {
        public List<MenuItem> Read(string menuFilePath)
        {
            var menuItems = new List<MenuItem>();
            string json = new StreamReader(menuFilePath + ".json").ReadToEnd();
            var items = JsonConvert.DeserializeObject<dynamic>(json)["FoodItemData"];

            foreach (var item in items)
            {
                string category = item["category"];
                menuItems.Add(new MenuItem
                {                   
                    Country = item["-country"].Value,
                    Category = Convert.ToString(item["category"]),
                    Name = item["name"],
                    Description = item["description"],
                    Price = Convert.ToDecimal(item["price"]),
                    Id = Convert.ToInt32(item["id"]),

                });
            }
            return menuItems;
        }

    }
}