using Api.Dtos;
using Api.IServices;
using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartment(int id)
    {
        var department = await _departmentService.GetDepartmentAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    [HttpPost]
    public async Task<ActionResult<Department>> CreateDepartment(CreateDepartmentDto createDepartmentDto)
    {
        var department = await _departmentService.CreateDepartmentAsync(createDepartmentDto);
        return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
    }
}