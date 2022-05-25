using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Models;
using Templet.DAL.Entities;

namespace Templet.BLL.Interface
{
   public interface ICityRep
    {
        IEnumerable<City> Get(Expression<Func<City, bool>> filter = null);
        City GetById(int id);
    }
}
