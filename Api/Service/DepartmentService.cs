using Api.DB;
using Api.Dtos;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class DepartmentService
{
    private readonly contextDb _context;

    public DepartmentService(contextDb context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department?> GetDepartmentAsync(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task<Department> DepartmentAsync(CreateDepartmentDto departmentDto)
    {
        var newDepartment = new Department
        {
            Name = departmentDto.Name
        };

        _context.Departments.Add(newDepartment);
        await _context.SaveChangesAsync();
        return newDepartment;
    }
}