using Api.DB;
using Api.Dtos;
using Api.IServices;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class DepartmentService : IDepartmentService
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

    public async Task<Department> CreateDepartmentAsync(CreateDepartmentDto departmentDto)
    {
        var newDepartment = new Department
        {
            Name = departmentDto.Name
        };

        _context.Departments.Add(newDepartment);
        await _context.SaveChangesAsync();
        return newDepartment;
    }

    public async Task<Department?> UpdateDepartmentAsync(int id, CreateDepartmentDto updatedDepartment)
    {
        var exitingDepartment = await _context.Departments.FindAsync(id);

        if (exitingDepartment == null)
        {
            return null;
        }

        exitingDepartment.Name = updatedDepartment.Name;
        await _context.SaveChangesAsync();
        return exitingDepartment;
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null)
        {
            return false;
        }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return true;
    }
}