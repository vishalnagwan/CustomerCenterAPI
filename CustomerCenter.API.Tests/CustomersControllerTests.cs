using CustomerCenter.API.Controllers;
using CustomerCenter.API.V1.Models;
using CustomerCenter.Domain.Data;
using CustomerCenter.Services.Abstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CustomerCenter.API.Tests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> _serviceMock;
        private readonly CustomersController _controller;

        public CustomersControllerTests()
        {
            _serviceMock = new Mock<ICustomerService>();
            _controller = new CustomersController(_serviceMock.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedResult_WithCreatedCustomer()
        {
            // Arrange
            var dto = new CustomerRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@doe.com",
                Phone = "1234567890",
                AddressLine1 = "123 Street",
                City = "NY",
                State = "NY",
                PostalCode = "10001",
                Country = "USA",
                IsActive = true
            };

            var created = new Customer { Id = 1, FirstName = "John" };

            _serviceMock
                .Setup(s => s.CreateAsync(It.IsAny<Customer>()))
                .ReturnsAsync(created);

            // Act
            var result = await _controller.Create(dto);

            // Assert
            var createdResult = result as CreatedAtActionResult;
            createdResult.Should().NotBeNull();
            createdResult!.Value.Should().BeEquivalentTo(created);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContent()
        {
            // Arrange
            var dto = new CustomerRequest
            {
                FirstName = "Updated",
                LastName = "User",
                Email = "updated@user.com",
                Phone = "9999999999",
                AddressLine1 = "New Address",
                City = "LA",
                State = "CA",
                PostalCode = "90001",
                Country = "USA",
                IsActive = true
            };

            _serviceMock
                .Setup(s => s.UpdateAsync(1, It.IsAny<Customer>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, dto);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }


        [Fact]
        public async Task Delete_ShouldReturnNoContent()
        {
            // Arrange
            _serviceMock
                .Setup(s => s.DeleteAsync(1))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }


        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenCustomerDoesNotExist()
        {
            // Arrange
            _serviceMock
                .Setup(s => s.GetByIdAsync(99))
                .ReturnsAsync((Customer?)null);

            // Act
            var result = await _controller.GetById(99);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public async Task GetAll_ShouldReturnListOfCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "A" },
                new Customer { Id = 2, FirstName = "B" }
            };

            _serviceMock
                .Setup(s => s.GetAllAsync())
                .ReturnsAsync(customers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var ok = result as OkObjectResult;
            ok.Should().NotBeNull();
            ok!.Value.Should().BeEquivalentTo(customers);
        }

    }
}
