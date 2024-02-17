using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Register
{
    public int Id { get; set; }

    public string EnrollNo { get; set; } = null!;

    public DateOnly EnrollDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Gender { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? PhoneNoOffice { get; set; }

    public string? PhoneNoRes { get; set; }

    public string CorresAddress { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public string TypeOfPerson { get; set; } = null!;

    public string Password { get; set; } = null!;
}
