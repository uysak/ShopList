using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICountryService
    {
        public IDataResult<List<Country>> GetAll();
        public IResult Create(Country country);
        public IDataResult<Country> GetById(int id);
        public IResult Update(Country country);
        public IResult Delete(int id);
    }
}
