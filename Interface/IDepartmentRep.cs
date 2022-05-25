using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Models;
using Templet.DAL.Entities;

namespace Templet.BLL.Interface
{
   public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetById(int id);
        void Add(DepartmentVM dpt);
        void Edit(DepartmentVM dpt);
        void Delete(int id);
        IQueryable<DepartmentVM> SearchByName(string Name);
    }
}
