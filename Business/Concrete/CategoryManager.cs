using Business.Abstract;
using Business.Aspects.Autofac.Validation;
using Business.Constants;
using Business.Services.Abstract;
using Business.Utilities.Results;
using Business.ValidationRule.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly ICacheService _cacheService;
        public CategoryManager(ICategoryDal categoryDal,ICacheService cacheService)
        {
            _categoryDal = categoryDal;
            _cacheService = cacheService;
        }

        public IDataResult<List<Category>> GetAll()
        {
            
            var result = _cacheService.GetOrAdd<List<Category>>("AllCategories", () => { return _categoryDal.GetAll(); });
            return new SuccessDataResult<List<Category>>(result);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Create(Category category)
        {
            _categoryDal.Add(category);
            _cacheService.Clear("AllCategories");
            return new SuccessResult();
        }
        public IDataResult<Category> Get(int id)
        {
            var result = _categoryDal.Get(s => s.Id == id);

            return result == null ? new ErrorDataResult<Category>(Messages.EntityNotFound) : new SuccessDataResult<Category>(result);
        }

        public IResult Update(Category category)
        {
            var updatedEntity = _categoryDal.Get(s => s.Id == category.Id);

            category.Description = category.Description == default ? updatedEntity.Description : category.Description;
            category.CategoryName = category.CategoryName == default ? updatedEntity.CategoryName : category.CategoryName;

            _categoryDal.Update(category);
            _cacheService.Clear("AllCategories");
            return new SuccessResult(Messages.EntityUpdated);
        }
        public IResult Delete(int id)
        {
            _categoryDal.Delete(_categoryDal.Get(s => s.Id == id));
            _cacheService.Clear("AllCategories");
            return new SuccessResult(Messages.EntityDeleted);
        }

    }
}
