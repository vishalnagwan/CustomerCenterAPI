using System;

namespace CustomerCenter.Domain.Data;

public class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;

    public bool IsActive { get; set; } = true;
    public string? LoyaltyNumber { get; set; }
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
