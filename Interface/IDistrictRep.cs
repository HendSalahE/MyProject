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
   public interface IDistrictRep
    {
        IEnumerable<District> Get(Expression<Func<District, bool>> filter = null);
        District GetById(int id);

    }
}
