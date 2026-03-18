using CustomerCenter.API.Controllers;
using CustomerCenter.API.V1.Models;
using CustomerCenter.Domain.Data;
using CustomerCenter.Services.Abstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using Xunit;

public class CustomerApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CustomerApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateCustomer_ShouldInsertIntoDatabase()
    {
        var dto = new CustomerRequest
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test@user.com",
            Phone = "1234567890",
            AddressLine1 = "123 Street",
            City = "NY",
            State = "NY",
            PostalCode = "10001",
            Country = "USA",
            IsActive = true
        };

        var response = await _client.PostAsJsonAsync("/api/customers", dto);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }
}
