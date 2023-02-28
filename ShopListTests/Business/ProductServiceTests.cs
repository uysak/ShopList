using Business.Abstract;
using Business.Concrete;
using Business.Services.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Moq;
using ShopListTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopListTests.Business
{
    using DataAccess.Abstract;
    using DataAccess.Concrete.EntityFramework;
    using Entities.Concrete;
    using FluentValidation.TestHelper;
    using global::Business.Constants;
    using global::Business.Services.Concrete;
    using global::Business.ValidationRule.FluentValidation;
    using StackExchange.Redis;
    using System.Linq;
    using Xunit;

    namespace Business.Tests
    {
        public class ProductManagerTests ///// Çalışmıyor
        {


            [Theory]
            [InlineData("", "", true, "Product name cannot be empty.", "Description cannot be empty.")]
            [InlineData("Product 1", "", true, "", "Description cannot be empty.")]
            [InlineData("", "Description 1", true, "Product name cannot be empty.", "")]
            [InlineData("Product 1", "Description 1", false, "", "")]
            [InlineData("Product1!", "Description1!", true, "Product name can only contain letters and numbers.", "Description can only contain letters and numbers.")]
            public void ProductValidator_ShouldValidateCorrectly(string productName, string description, bool expectedValidationResult, string expectedProductNameError, string expectedDescriptionError)
            {
                // Arrange
                var validator = new ProductValidator();
                var product = new Product
                {
                    ProductName = productName,
                    Description = description
                };

                // Act
                var validationResult = validator.Validate(product);

                // Assert
                Assert.Equal(expectedValidationResult, validationResult.IsValid);
                Assert.Equal(expectedProductNameError, validationResult.Errors.FirstOrDefault(x => x.PropertyName == "ProductName")?.ErrorMessage);
                Assert.Equal(expectedDescriptionError, validationResult.Errors.FirstOrDefault(x => x.PropertyName == "Description")?.ErrorMessage);
            }


        }
    }

}
