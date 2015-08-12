using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FormatterFactory
    {
        public IMenuFormatter CreateFormatter(string type)
        {
            switch (type)
            {
                case "Plain":
                    return new PlainTextMenuFormatter();
                case "XML":
                    return new XmlMenuFormatter();
                case "HTML":
                    return new HtmlMenuFormatter();
            }
            return null;
        }
    }
}