using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.BLL.Interface;
using Templet.BLL.Models;
using Templet.DAL.Database;

namespace Templet.BLL.Repository
{
   public class CountryRep:ICountryRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //private DbContainer db =new DbContainer();
        public CountryRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllDepts();
            return data;
        }

        private IQueryable<CountryVM> GetAllDepts()
        {
            return db.Country.Select(a => new CountryVM { ID = a.ID, CountryName = a.CountryName });
        }

        public CountryVM GetById(int id)
        {
            CountryVM data = GetDepartmentByID(id);
            return data;
        }

        private CountryVM GetDepartmentByID(int id)
        {
            return db.Country.Where(a => a.ID == id)
                .Select(a => new CountryVM { ID = a.ID, CountryName = a.CountryName })
                .FirstOrDefault();
        }

    }
}
