using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.test
{
    [TestClass]
    public class ProductManagerTests
    {
        [TestMethod]
        public void Create_WhenCalledWithValidProductAndCategoryId_ShouldReturnSuccessResult()
        {
            // Arrange
            var product = new Product
            {
                // TODO: Product nesnesini istediğin şekilde doldur
            };
            var categoryId = 1; // TODO: Test için uygun bir categoryId belirle

            var productDal = new Mock<IProductDal>();
            var productCategoryDal = new Mock<IProductCategoryDal>();
            var validator = new Mock<IValidator<Product>>();
            var logger = new Mock<ILogger<ProductManager>>();

            var productManager = new ProductManager(productDal.Object, productCategoryDal.Object, validator.Object, logger.Object);

            // Act
            var result = productManager.Create(product, categoryId);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }


    [TestMethod]
    public void Create_WhenProductIsNotValid_ReturnsErrorResult()
    {
        // Arrange
        var productService = new Mock<IProductService>();
        var productValidator = new Mock<IValidator<Product>>();
        productValidator.Setup(x => x.Validate(It.IsAny<Product>()).IsValid).Returns(false);
        var product = new Product();
        var categoryId = 1;
        var expected = new ErrorResult("Validation error");
        var sut = new ProductController(productService.Object, productValidator.Object);

        // Act
        var result = sut.CreateProduct(product, categoryId);

        // Assert
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        var actual = ((BadRequestObjectResult)result).Value;
        Assert.AreEqual(expected.Message, ((ErrorResult)actual).Message);
    }


    [TestCase(3, 3, 6)]
    [TestCase(0, 0, 0)]
    [TestCase(-5, 7, 2)]
    public void Test_Addition(int a, int b, int expected)
    {
        // Arrange

        // Act
        int result = Calculator.Addition(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }



}
