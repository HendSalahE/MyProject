using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Templet.BLL.Helper;
using Templet.BLL.Interface;
using Templet.BLL.Models;
using Templet.DAL.Entities;

namespace Templet.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IMapper mapper;





        public EmployeeController(IEmployeeRep employee,IDepartmentRep _department, ICountryRep country, ICityRep city, IDistrictRep district,IMapper mapper)
        {
            this.employee = employee;
            department = _department;
            this.country = country;
            this.city = city;
            this.district = district;
            this.mapper = mapper;
        }

        public IActionResult Index(string EName ="")
        {
            if (EName == "")
            {
                var data = employee.Get();

                return View(data);

            }
            else
            {
                var data = employee.Search(EName);

                return View(data);
            }
            


        }
        public IActionResult Details(int id)
        {
            var data = employee.GetById(id);
            var Dptdata = department.Get();
            var countrydata = country.Get();

            ViewBag.DepartmentList = new SelectList(Dptdata, "ID", "DepartmentName", data.DepartmentID);
            //ViewBag.CountryList = new SelectList(countrydata, "ID", "CountryName", data.DistrictID);

            return View(data);
        }
        public IActionResult Create()
        {
            var data = department.Get();
            var countydata = country.Get();
            ViewBag.DepartmentList = new SelectList(data,"ID","DepartmentName");
            ViewBag.CountryList = new SelectList(countydata, "ID", "CountryName");

            var Districtdata = district.Get();
            ViewBag.DistrictList = new SelectList(Districtdata, "ID", "DistrictName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    employee.Add(emp);
                    return RedirectToAction("Index");
                }
                var data = department.Get();
                ViewBag.DepartmentList = new SelectList(data, "ID", "DepartmentName");
                var countydata = country.Get();
                ViewBag.CountryList = new SelectList(countydata, "ID", "CountryName");

                var Districtdata = district.Get();
                ViewBag.DistrictList = new SelectList(Districtdata, "ID", "DistrictName");
                return View();

            }
            catch (Exception ex)
            {
                var data = department.Get();
                ViewBag.DepartmentList = new SelectList(data, "ID", "DepartmentName");
                var countydata = country.Get();
                ViewBag.CountryList = new SelectList(countydata, "ID", "CountryName");

                var Districtdata = district.Get();
                ViewBag.DistrictList = new SelectList(Districtdata, "ID", "DistricttName");

                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            var Deptdata = department.Get();
            ViewBag.DepartmentList = new SelectList(Deptdata, "ID", "DepartmentName", data.DepartmentID);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
        }
        var Deptdata = department.Get();
        ViewBag.DepartmentList = new SelectList(Deptdata, "ID", "DepartmentName", emp.DepartmentID);
                return View();

    }
            catch (Exception ex)
            {
                var Deptdata = department.Get();
    ViewBag.DepartmentList = new SelectList(Deptdata, "ID", "DepartmentName", emp.DepartmentID);
                return View();

}
        }
        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);

           
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
               
                employee.Delete(id);
                return RedirectToAction("Index", "Empolyee");



            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View();
            }
        }


        //-----------call-- AJAX---------------
        //[HttpPost]
        //public JsonResult GetCityDataByCountryId(int CtryId)
        //{
        //    var model = city.Get(a => a.CountryID == CtryId);
        //    var data = mapper.Map<IEnumerable<CityVM>>(model);
        //    return Json(data);
        //}

        //[HttpPost]
        //public JsonResult GetDistrictDataByCityId(int CtyId)
        //{
        //    var model = district.Get(a => a.CityID == CtyId);
        //    var data = mapper.Map<IEnumerable<DistrictVM>>(model);
        //    return Json(data);
        //}

    }
}
