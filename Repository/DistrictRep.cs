using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Interface;
using Templet.BLL.Models;
using Templet.DAL.Database;
using Templet.DAL.Entities;

namespace Templet.BLL.Repository
{
   public class DistrictRep:IDistrictRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db =new DbContainer();
        public DistrictRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public IEnumerable<District> Get(Expression<Func<District, bool>> filter = null)
        {
            var data = db.District.Select(a => a);

            if (filter != null)
            {
                data = db.District.Where(filter);
            }
            return data;
        }


        public District GetById(int id)
        {
            var data = db.District.Where(a => a.ID == id).FirstOrDefault();
            return data;
        }
    }
}
