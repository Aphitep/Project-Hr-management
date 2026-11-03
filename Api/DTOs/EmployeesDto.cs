namespace Api.Dtos;

public class CreateEmployeesDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public DateTime? CreatedAt { get; set; }
}

public class UpdateEmployeesDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public decimal? Salary { get; set; }
}