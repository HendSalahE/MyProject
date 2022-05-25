using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Interface;
using Templet.BLL.Models;
using Templet.DAL.Database;
using Templet.DAL.Entities;

namespace Templet.BLL.Repository
{
   public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db =new DbContainer();
        public DepartmentRep(DbContainer db,IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public void Add(DepartmentVM dpt)
        {
            //Department d =new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);

            db.Department.Add(data);
            db.SaveChanges();
        }

        
        public void Delete(int id)
        {
            var DeleteObject = db.Department.Find(id);
            db.Department.Remove(DeleteObject);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        {

            //var OldData = db.Department.Find(dpt.ID);
            //OldData.DepartmentName = dpt.DepartmentName;
            //OldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;
        }

        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Department.Select(a => new DepartmentVM { ID = a.ID, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

        public DepartmentVM GetById(int id)
        {
            DepartmentVM data = GetDepartmentByID(id);
            return data;
        }

        private DepartmentVM GetDepartmentByID(int id)
        {
            return db.Department.Where(a => a.ID == id)
                .Select(a => new DepartmentVM { ID = a.ID, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                .FirstOrDefault();
        }

        public IQueryable<DepartmentVM> SearchByName(string Name)
        {

            var model = db.Department.Where(a => a.DepartmentName.Contains(Name)).Select(a => new DepartmentVM { ID = a.ID, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                 ;
          
            return model;
        }
    }
}
