
using Praktyki_projectDotNET.Repositories;
using Praktyki_projectDotNET.Model;
using Praktyki_projectDotNET.Controllers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Praktyki_projectDotNET.Tests { 
    public class ProductControllerTest
{
    [Fact]
    public void GetAllReturnsProducts()
    {
        // Arrange
        var mockService = new Mock<IProductService>();
        var mockLogger = new Mock<ILogger<ProductController>>();
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "milk", Price = 12.5, Category = "groceries" },
            new Product { Id = 2, Name = "TV", Price = 340.8, Category = "household" }
        };
        mockService.Setup(service => service.GetAll()).Returns(products);

        var controller = new ProductController(mockService.Object, mockLogger.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result); // Checks if the result is of type OkObjectResult
        var returnProducts = Assert.IsType<List<Product>>(okResult.Value); // Checks if the value inside the result is of type List<Product>
        Assert.Equal(products, returnProducts); //
    }
}
}
