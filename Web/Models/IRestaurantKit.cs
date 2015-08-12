using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public interface IRestaurantKit
    {
        IMenuReader GetMenuReader(string country);
        IMenuGenerator GetMenuGenerator(IMenuReader menuReader, List<MenuItem> menuItems);
        IMenuFormatter GetMenuFormatter(string type);
    }

    public class RestaurantKit : IRestaurantKit
    {

        public IMenuReader GetMenuReader(string country)
        {
            var factory = new ReaderFactory();
            IMenuReader reader = null;
            switch (country)
            {
                case "US":
                    reader = factory.CreateReader(ReaderType.JSON);
                    break;
                case "GB":
                    reader = factory.CreateReader(ReaderType.XML);
                    break;
            }
            return reader;           
        }

        public IMenuGenerator GetMenuGenerator(IMenuReader menuReader, List<MenuItem>menuItems)
        {
            Type menuReaderType = menuReader.GetType();
            IMenuGenerator generator = null;
            switch (menuReaderType.Name)
            {
                case "JsonMenuReader":
                    generator = new USMenuGenerator(menuItems);
                    break;
                case "XmlMenuReader":
                    generator = new GBMenuGenerator(menuItems);
                    break;
            }

            return generator;
        }

        public IMenuFormatter GetMenuFormatter(string downloadType)
        {
            var factory = new FormatterFactory();
            IMenuFormatter menuFormatter = factory.CreateFormatter(downloadType);

            return menuFormatter;
        }
    }
}