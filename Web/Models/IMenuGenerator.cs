using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public interface IMenuGenerator
    {
        List<MenuItem> GetDinerItems();
        List<MenuItem> GetAllDayItems();
        List<MenuItem> GetEveningOnlyItems();
    }
}