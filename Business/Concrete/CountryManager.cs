using Business.Abstract;
using Business.Constants;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public IResult Create(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult(Messages.EntityCreated);
        }

        public IResult Delete(int id)
        {
            _countryDal.Delete(_countryDal.Get(s => s.Id == id));
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<Country> GetById(int id)
        {
            var result = _countryDal.Get(s => s.Id == id);
            return new SuccessDataResult<Country>(result);
        }

        public IDataResult<List<Country>> GetAll()
        {
            var result = _countryDal.GetAll();
            return new SuccessDataResult<List<Country>>(result);
        }

        public IResult Update(Country country)
        {
            var updatedEntity = _countryDal.Get(s => s.Id == country.Id);

            country.CountryName = country.CountryName == default ? updatedEntity.CountryName : country.CountryName;
            country.FlagImgLink = country.FlagImgLink == default ? updatedEntity.FlagImgLink : country.FlagImgLink;

            _countryDal.Update(country);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
