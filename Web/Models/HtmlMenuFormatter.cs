using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace Web.Models
{
    public class HtmlMenuFormatter : IMenuFormatter
    {
        public byte[] GetDownloadBytes(List<MenuItem> menuItems)
        {
            HtmlTextWriter html = new HtmlTextWriter(new System.IO.StringWriter());
            foreach (var category in Enum.GetValues(typeof(CategoryOrder)))
            {
                var relevantItems = menuItems.Where(i => i.Category == MenuFormatter.GetCategory((CategoryOrder)category));
                if (relevantItems.Count() == 0) continue;

                html.RenderBeginTag(HtmlTextWriterTag.Div);
                html.Write(category.ToString());
                html.RenderEndTag();

                foreach (var item in relevantItems)
                {
                    html.RenderBeginTag(HtmlTextWriterTag.Ul);

                    html.RenderBeginTag(HtmlTextWriterTag.Li);
                    html.Write(item.Name);
                    html.RenderEndTag();

                    html.RenderBeginTag(HtmlTextWriterTag.Li);
                    html.Write(item.Description);
                    html.RenderEndTag();

                    html.RenderBeginTag(HtmlTextWriterTag.Li);
                    html.Write((item.Country == "US" ? "USD" : "GBP") + " " + item.Price);
                    html.RenderEndTag();

                    html.RenderEndTag();
                }
            }

            return System.Text.Encoding.ASCII.GetBytes(html.InnerWriter.ToString());
        }
    }
}