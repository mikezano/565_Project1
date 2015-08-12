using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Web.Models
{
    public class XmlMenuReader : IMenuReader
    {
        public List<MenuItem> Read(string menuFilePath)
        {
            var menuItems = new List<MenuItem>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(menuFilePath + ".xml");

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("FoodItem");
            
            foreach (XmlNode node in nodes)
            {
                menuItems.Add(new MenuItem
                {
                    Id = Convert.ToInt32(node.SelectSingleNode(".//id").InnerText),
                    Name = node.SelectSingleNode(".//name").InnerText,
                    Description = node.SelectSingleNode(".//description").InnerText,
                    Category = node.SelectSingleNode(".//category").InnerText,
                    Country = node.Attributes["country"].Value,
                    Price = Convert.ToDecimal(node.SelectSingleNode(".//price").InnerText)
                });
            }
            return menuItems;
        }
    }
}