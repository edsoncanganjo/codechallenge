using CodeChallenge.Api.Contracts;
using CodeChallenge.Api.Controllers;
using CodeChallenge.Api.Entities;
using CodeChallenge.Api.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CodeChallenge.Api.Tests;

public class TestProductsController
{
    [Fact]
    public async Task GetAll_OnSuccess_ShouldReturnStatusCode200Ok()
    {
        // Arrange
        CancellationToken cancellationToken = new();
        var mockProductsRepository = new Mock<IProductsRepository>();
        
        var controller = new ProductsController(mockProductsRepository.Object);
        
        // Act
        var result = (OkObjectResult)await controller.GetAll(cancellationToken);
        
        // Assert
        result.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
    
    [Fact]
    public async Task Add_OnSuccess_ShouldReturnStatusCode201()
    {
        // Arrange
        CancellationToken cancellationToken = new();
        var mockProductsRepository = new Mock<IProductsRepository>();
        
        var controller = new ProductsController(mockProductsRepository.Object);
        
        // Act
        var product = new ProductInput("IPhone 16 Pro", 1560);
        var result = (CreatedAtActionResult)await controller.Add(product, cancellationToken);
        
        // Assert
        result.StatusCode.Should().Be(StatusCodes.Status201Created);
    }
    
    [Fact]
    public async Task Delete_OnSuccess_ShouldReturnStatusCode204()
    {
        // Arrange
        CancellationToken cancellationToken = new();
        var mockProductsRepository = new Mock<IProductsRepository>();

        Product mockProduct = new()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone 16 Pro Max",
            Price = 1680
        };

        mockProductsRepository.Setup(r => r.GetByIdAsync(mockProduct.Id, cancellationToken)).ReturnsAsync(mockProduct);
        mockProductsRepository.Setup(r => r.DeleteAsync(mockProduct.Id, cancellationToken));
        
        var controller = new ProductsController(mockProductsRepository.Object);
        
        // Act
        var result = (NoContentResult)await controller.Delete(mockProduct.Id, cancellationToken);
        
        // Assert
        result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
    }
    
    [Fact]
    public async Task Delete_OnInvalidId_ShouldReturnStatusCode404()
    {
        // Arrange
        CancellationToken cancellationToken = new();
        var mockProductsRepository = new Mock<IProductsRepository>();

        Product mockProduct = new()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone 16 Pro Max",
            Price = 1680
        };

        mockProductsRepository.Setup(r => r.GetByIdAsync(mockProduct.Id, cancellationToken)).ReturnsAsync(mockProduct);
        mockProductsRepository.Setup(r => r.DeleteAsync(mockProduct.Id, cancellationToken));
        
        var controller = new ProductsController(mockProductsRepository.Object);
        
        // Act
        var result = (NotFoundResult)await controller.Delete(Guid.NewGuid(), cancellationToken);
        
        // Assert
        result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}