using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.DAL.Entities;

namespace Templet.BLL.Models
{
   public class CityVM
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        
    }
}
