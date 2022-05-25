using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Models;

namespace Templet.BLL.Interface
{
   public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetById(int id);
        void Add(EmployeeVM emp);
        void Edit(EmployeeVM emp);
        void Delete(int id);
        IQueryable<EmployeeVM> Search(string EName);
    }
}
