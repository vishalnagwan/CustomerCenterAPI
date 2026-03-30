using Castle.Core.Logging;
using Castle.Core.Resource;
using CustomerCenter.API.V1.Models;
using CustomerCenter.Domain;
using CustomerCenter.Domain.Data;
using CustomerCenter.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCenter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;
    private ILogger<CustomersController> _logger;

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

    [HttpPost("Update")]
    public async Task<IActionResult> Update([FromBody] CustomerRequest dto)
    {
        try
        {
            await _service.UpdateAsync(new Customer
            {
                Id = dto.Id,
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
            _logger.LogWarning("Updated successfully");
            return Ok("Updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update failed");
            return StatusCode(500, "Update failed");
        }
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Deleted successfully.");
    }
}
