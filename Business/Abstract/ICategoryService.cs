using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IDataResult<List<Category>> GetAll();
        public IResult Create(Category category);
        public IDataResult<Category> Get(int id);
        public IResult Update(Category category);
        public IResult Delete(int id);

    }
}
