using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public IDataResult<List<Product>> GetAll();
        public IResult Create(Product product);
        public IDataResult<Product> Get(int id);
        public IResult Update(Product product);
        public IResult Delete(int id);
    }
}
