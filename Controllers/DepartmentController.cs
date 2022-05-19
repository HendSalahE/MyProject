using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templet.BLL.Models;
using Templet.BLL.Repository;
using Templet.DAL.Database;
using System.Diagnostics;
using Templet.BLL.Interface;

namespace Templet.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRep department;

        public DepartmentController(IDepartmentRep department)
        {
            this.department = department;
        }
        [HttpGet]
        public IActionResult Index(string Dname="")
        {
            if(Dname=="")
            {
                var data = department.Get();

                return View(data);


            }
            else
            {
                var data = department.SearchByName(Dname);


                return View(data);
            }
           
            
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM dpt )
        {
            try {
                if (ModelState.IsValid)
                {
                    department.Add(dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(dpt);
                
            }
            catch(Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(dpt);
            }
        }
        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Edit(dpt);
                    return RedirectToAction("Index", "Department");
                }
                return View(dpt);

            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(dpt);
            }
        }
        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                
                
                    department.Delete(id);
                    return RedirectToAction("Index", "Department");
                
              

            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashbord";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View();
            }
        }

    }
}