using Business.Abstract;
using Business.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Utilities.Results;
using Business.ValidationRule.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StatusManager : IStatusService
    {
        private readonly IStatusDal _statusDal;
        public StatusManager(IStatusDal statusDal)
        {
            _statusDal = statusDal;
        }

        [ValidationAspect(typeof(StatusValidator))]
        [SecuredOperation("Admin")]
        public IResult Create(Status status)
        {
            _statusDal.Add(status);
            return new SuccessResult(Messages.EntityCreated);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(int id)
        {
            _statusDal.Delete(_statusDal.Get(s => s.Id == id));
            return new SuccessResult(Messages.EntityDeleted);
        }

        [SecuredOperation("Admin")]
        public IDataResult<Status> GetById(int id)
        {
            var result = _statusDal.Get(s => s.Id == id);
            return new SuccessDataResult<Status>(result);
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<Status>> GetAll()
        {
            var result = _statusDal.GetAll();
            return new SuccessDataResult<List<Status>>(result);
        }
        [SecuredOperation("Admin")]
        public IResult Update(Status status)
        {
            var updatedEntity = _statusDal.Get(s => s.Id == status.Id);

            status.StatusName = status.StatusName == default ? updatedEntity.StatusName : status.StatusName;
            status.StatusDescription = status.StatusDescription == default ? updatedEntity.StatusDescription : status.StatusDescription;

            _statusDal.Update(status);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}

