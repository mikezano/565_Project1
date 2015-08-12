using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Web.Models
{

    public class XmlMenuFormatter : IMenuFormatter
    {
        public byte[] GetDownloadBytes(List<MenuItem> menuItems)
        {

            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("MenuItems");
            xml.AppendChild(root);

            foreach (var category in Enum.GetValues(typeof(CategoryOrder)))
            {
                var relevantItems = menuItems.Where(i => i.Category == MenuFormatter.GetCategory((CategoryOrder)category));
                if (relevantItems.Count() == 0) continue;



                XmlElement foodItemCategory = xml.CreateElement("FoodItemCategory");
                XmlAttribute categoryAttribute = xml.CreateAttribute("category");
                categoryAttribute.InnerText = category.ToString();
                foodItemCategory.Attributes.Append(categoryAttribute);

                foreach (var item in relevantItems)
                {
                    XmlElement menuItem = xml.CreateElement("MenuItem");

                    XmlElement itemName = xml.CreateElement("Name");
                    itemName.InnerText = item.Name;

                    XmlElement price = xml.CreateElement("Price");
                    XmlElement currencyCode = xml.CreateElement("CurrencyCode");
                    currencyCode.InnerText = item.Country == "US" ? "USD" : "GBP";
                    XmlElement amount = xml.CreateElement("Amount");
                    amount.InnerText = item.Price.ToString();
                    price.AppendChild(currencyCode);
                    price.AppendChild(amount);

                    XmlElement description = xml.CreateElement("Description");
                    description.InnerText = item.Description;

                    menuItem.AppendChild(itemName);
                    menuItem.AppendChild(price);
                    menuItem.AppendChild(description);


                    foodItemCategory.AppendChild(menuItem);
                }

                root.AppendChild(foodItemCategory);
            }

            return System.Text.Encoding.ASCII.GetBytes(xml.InnerXml);
        }
    }
}