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
   public class CityRep: ICityRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db =new DbContainer();
        public CityRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public IEnumerable<City> Get(Expression<Func<City, bool>> filter = null)
        {
            var data = db.City.Select(a => a);

            if (filter != null)
            {
                data = db.City.Where(filter);
            }

            return data;
        }


        public City GetById(int id)
        {
            var data = db.City.Where(a => a.ID == id).FirstOrDefault();
            return data;
        }
    }
}
