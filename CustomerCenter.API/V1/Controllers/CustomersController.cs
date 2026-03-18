using Castle.Core.Resource;
using CustomerCenter.API.V1.Models;
using CustomerCenter.Domain.Data;
using CustomerCenter.Domain;
using CustomerCenter.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace CustomerCenter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
        => Ok((await _service.GetAllAsync()));

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var customer = await _service.GetByIdAsync(id);        
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CustomerRequest dto)
    {
        var created = await _service.CreateAsync(new Customer
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            DateOfBirth = dto.DateOfBirth,
            AddressLine1 = dto.AddressLine1,
            AddressLine2 = dto.AddressLine2,
            City = dto.City,
            State = dto.State,
            PostalCode = dto.PostalCode,
            Country = dto.Country,
            IsActive = true,
            LoyaltyNumber = dto.LoyaltyNumber,
            Notes = dto.Notes
        });

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(int id, CustomerRequest dto)
    {
        await _service.UpdateAsync(id, new Customer
        {
            Id = id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            DateOfBirth = dto.DateOfBirth,
            AddressLine1 = dto.AddressLine1,
            AddressLine2 = dto.AddressLine2,
            City = dto.City,
            State = dto.State,
            PostalCode = dto.PostalCode,
            Country = dto.Country,
            IsActive = dto.IsActive,
            LoyaltyNumber = dto.LoyaltyNumber,
            Notes = dto.Notes
        });

        return Ok("Updated successfully");
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Deleted successfully.");
    }
}
