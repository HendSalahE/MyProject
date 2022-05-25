using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.DAL.Entities;

namespace Templet.BLL.Models
{
   public class DistrictVM
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
