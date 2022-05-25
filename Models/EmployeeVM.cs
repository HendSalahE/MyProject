using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templet.BLL.Models
{
   public class EmployeeVM
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        [MinLength(3, ErrorMessage = "Min Length 3 ")]
        [MaxLength(10, ErrorMessage = "Max Length 10 ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Adress")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}",ErrorMessage ="Enter like 12-streetMame-cityName-countryName")]
        public string Adress { get; set; }
        public string Email { get; set; }
        public DateTime HireData { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        [Range(3000,10000,ErrorMessage ="Enter Salary from 3000 to 10000")]
        public float Salary { get; set; }
        public string DepartmentID { get; set; }
        public string DistrictID { get; set; }

        public string CvUrl { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile Cv { get; set; }
        public IFormFile Img { get; set; }

    }
}
