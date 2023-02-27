using Business.Abstract;
using Business.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Utilities.Results;
using Business.ValidationRule.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(CountryValidator))]
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

        [SecuredOperation("Admin")]
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

            new ValidationAspect(typeof(CountryValidator));

            _countryDal.Update(country);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
