using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Helper;
using Templet.BLL.Interface;
using Templet.BLL.Models;
using Templet.DAL.Database;
using Templet.DAL.Entities;

namespace Templet.BLL.Repository
{
   public class EmployeeRep:IEmployeeRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db =new DbContainer();
        public EmployeeRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public void Add(EmployeeVM emp)
        {
            //Department d =new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Employee>(emp);
           data.ImgUrl= UploadFileHelper.SaveFile(emp.Img,"/wwwroot/Files/IMGs/");
           data.CvUrl= UploadFileHelper.SaveFile(emp.Cv, "/wwwroot/Files/CVs/");
            
            db.Employee.Add(data);
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            var DeleteObject = db.Employee.Find(id);
            db.Employee.Remove(DeleteObject);
            UploadFileHelper.FileRemove("Files/CVs", DeleteObject.CvUrl);
            UploadFileHelper.FileRemove("Files/IMGs", DeleteObject.ImgUrl);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {

            //var OldData = db.Department.Find(dpt.ID);
            //OldData.DepartmentName = dpt.DepartmentName;
            //OldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Employee>(emp);

            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllemps();
            return data;
        }

        private IQueryable<EmployeeVM> GetAllemps()
        {
            return db.Employee.Select(a => new EmployeeVM { ID = a.ID, Name = a.Name, Salary = a.Salary, Adress = a.Adress,HireData=a.HireData,IsActive=a.IsActive,Notes=a.Notes,Email=a.Email,DepartmentID=a.Department.DepartmentName ,DistrictID=a.District.DistrictName,CvUrl=a.CvUrl,ImgUrl=a.ImgUrl}) ;
        }

        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeByID(id);
            return data;
        }

        private EmployeeVM GetEmployeeByID(int id)
        {
            return db.Employee.Where(a => a.ID == id)
                .Select(a => new EmployeeVM { ID = a.ID, Name = a.Name, Salary = a.Salary, Adress = a.Adress, HireData = a.HireData, IsActive = a.IsActive, Notes = a.Notes, Email = a.Email,DepartmentID = a.Department.DepartmentName, DistrictID = a.District.DistrictName,CvUrl=a.CvUrl,ImgUrl=a.ImgUrl })
                .FirstOrDefault();
        }

        public IQueryable<EmployeeVM> Search(string EName)
        {
            var data = db.Employee.Where(a => a.Name.Contains(EName))
                .Select(a => new EmployeeVM { ID = a.ID, Name = a.Name, Salary = a.Salary, Adress = a.Adress, HireData = a.HireData, IsActive = a.IsActive, Notes = a.Notes, Email = a.Email, DepartmentID = a.Department.DepartmentName, DistrictID = a.District.DistrictName, CvUrl = a.CvUrl, ImgUrl = a.ImgUrl });
            return data;
        }
    }
}
