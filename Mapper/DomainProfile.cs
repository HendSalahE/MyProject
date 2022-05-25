using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Models;
using Templet.DAL.Entities;

namespace Templet.BLL.Mapper
{
   public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM,Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();
        }
    }
}
