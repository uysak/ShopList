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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result);
        }

        public IResult Create(Category category)
        {
            _categoryDal.Add(category);
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
            return new SuccessResult(Messages.EntityUpdated);
        }
        public IResult Delete(int id)
        {
            _categoryDal.Delete(_categoryDal.Get(s => s.Id == id));
            return new SuccessResult(Messages.EntityDeleted);
        }

    }
}
