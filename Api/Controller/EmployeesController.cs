using Api.DB;
using Api.Dtos;
using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService _service)
    {
        _employeeService = _service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        return await _employeeService.GetAllEmployeesAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeesDto createEmployeeDto)
    {
        var employee = await _employeeService.CreateEmployeeAsync(createEmployeeDto);

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
    }
}