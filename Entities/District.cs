using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Templet.DAL.Entities
{
    [Table("District")]
    public class District
    {
        public int ID { get; set; }
        public string DistrictName { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
