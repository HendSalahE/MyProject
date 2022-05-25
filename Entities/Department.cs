using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Templet.DAL.Entities
{
    [Table("Departmet")]
   public class Department
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        [StringLength(20)]
        public string DepartmentCode { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }

    }
}
