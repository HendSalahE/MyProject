using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Templet.DAL.Entities
{
    [Table("City")]
    public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public ICollection<District> District { get; set; }
    }
}
