using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Templet.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<City> City { get; set; }
    }
}
