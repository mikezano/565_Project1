using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public interface IMenuReader
    {
        List<MenuItem> Read(string menuFilePath);
    }
}
