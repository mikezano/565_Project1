using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mime;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var factory = new ReaderFactory();
            var reader = factory.CreateReader(ReaderType.XML);
            var menuItems = reader.Read(Server.MapPath("~/Content/FoodItemData"));
            return View();
        }

        public ActionResult SelectReader(ReaderType type){
            var factory = new ReaderFactory();
            var reader = factory.CreateReader(type);
            //reader
            return null;
        }

        [HttpGet]
        public JsonResult GetMenuItems(string country)
        {
            var restaurantKit = new RestaurantKit();
            var reader = restaurantKit.GetMenuReader(country);
            var menuItems = reader.Read(Server.MapPath("~/Content/FoodItemData"));
            var menuGenerator = restaurantKit.GetMenuGenerator(reader, menuItems);

            List<MenuItem> filteredMenuItems = new List<MenuItem>(); 
            filteredMenuItems.AddRange(
                menuGenerator.GetAllDayItems().Union(
                    menuGenerator.GetDinerItems().Union(
                        menuGenerator.GetEveningOnlyItems())));

            return Json(filteredMenuItems, JsonRequestBehavior.AllowGet);
        }

        public FileResult Download(string restaurantType, string downloadType, string country)
        {
            var restaurantKit = new RestaurantKit();
            var reader = restaurantKit.GetMenuReader(country);
            var menuItems = reader.Read(Server.MapPath("~/Content/FoodItemData"));
            var menuGenerator = restaurantKit.GetMenuGenerator(reader, menuItems);
            var filteredMenuItems = GetItemsByRestaurantType(menuGenerator, restaurantType);
            var formatter = restaurantKit.GetMenuFormatter(downloadType);           
            var bytes  = formatter.GetDownloadBytes(filteredMenuItems);

            Response.ContentType = GetContentType(downloadType);
            Response.AddHeader("Content-disposition", "attachment;filename=" + country + " " + restaurantType + "." + GetFileExtension(downloadType));
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();

            return File(Response.OutputStream, MediaTypeNames.Application.Octet);
        }

        private List<MenuItem> GetItemsByRestaurantType(IMenuGenerator menuGenerator, string restaurantType)
        {
            switch (restaurantType)
            {
                case "Diner":
                    return menuGenerator.GetDinerItems();
                case "EveningOnly":
                    return menuGenerator.GetEveningOnlyItems();
                case "AllDay":
                    return menuGenerator.GetAllDayItems();
            }
            return null;
        }

        private string GetFileExtension(string downloadType){
            string result = null;
            switch(downloadType)
            {
                case "Plain":
                    result =  "txt";
                    break;
                case "HTML":
                    result =  "html";
                    break;
                case "XML":
                    result = "xml";
                    break;
            }
            return result;
        }

        private string GetContentType(string downloadType)
        {
            string result = null;
            switch (downloadType)
            {
                case "Plain":
                    result = "text/plain";
                    break;
                case "HTML":
                    result =  "text/HTML";
                    break;
                case "XML":
                    result =  "text/xml";
                    break;
            }
            return result;
        }
    }


}