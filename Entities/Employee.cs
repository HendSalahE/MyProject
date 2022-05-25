using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templet.DAL.Entities
{
    [Table("Employee")]
   public class Employee
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        
        public string Adress { get; set; }
        public string Email { get; set; }
        public DateTime HireData { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public float Salary { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
        public int DistrictID { get; set; }
        public District District { get; set; }
        public string CvUrl { get; set; }
        public string ImgUrl { get; set; }



    }
}
