using Business.Abstract;
using Business.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.Services.Abstract;
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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductCategoryDal _productCategoryDal;
        private readonly ICacheService _cacheService;
        public ProductManager(IProductDal productDal,IProductCategoryDal productCategoryDal, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _productDal = productDal;
            _productCategoryDal = productCategoryDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Create(Product product, int categoryId)
        {
            
            var productForCheck = _productDal.Get(s=> s.ProductName == product.ProductName);
            if(productForCheck != null)
            {
                return new ErrorResult();
            }

            _productDal.Add(product);
            _productCategoryDal.Add( // TODO: Vaktin kalırsa business katmanını da oluştur
                new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = categoryId
                });
            return new SuccessResult(Messages.EntityCreated);
        }

        [SecuredOperation("Admin")]
        public IResult Delete(int id)
        {
            _productDal.Delete(_productDal.Get(s => s.Id == id));
            return new SuccessResult(Messages.EntityDeleted);
        }

        [SecuredOperation("Admin,User")]
        public IDataResult<Product> Get(int id)
        {
            var result = _productDal.Get(s => s.Id == id);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _cacheService.GetOrAdd<List<Product>>("AllProducts", () => { return _productDal.GetAll(); });
            return new SuccessDataResult<List<Product>>(result);
        }
        [SecuredOperation("Admin")]
        public IResult Update(Product product)
        {
            var updatedEntity = _productDal.Get(s=>s.Id == product.Id);
            
            product.ProductName = product.ProductName == default ? updatedEntity.ProductName : product.ProductName;
            product.Description = product.Description == default ? updatedEntity.Description : product.Description;

            _productDal.Update(product);
            _cacheService.Clear("AllProducts");
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
