using Api.DB;
using Api.Dtos;
using Api.IServices;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Service;

public class EmployeeService : IEmployeeService
{
    private readonly contextDb _context;

    public EmployeeService(contextDb context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateEmployeeAsync(CreateEmployeesDto employee)
    {
        var newEmployee = new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Salary = employee.Salary,
            CreatedAt = DateTime.UtcNow
        };

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return newEmployee;
    }

    public async Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeesDto updatedEmployee)
    {
        var existingEmployee = await _context.Employees.FindAsync(id);
        if (existingEmployee == null)
        {
            return null;
        }

        existingEmployee.FirstName = updatedEmployee.FirstName ?? existingEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName ?? existingEmployee.LastName;
        existingEmployee.Email = updatedEmployee.Email ?? existingEmployee.Email;
        existingEmployee.Salary = updatedEmployee.Salary ?? existingEmployee.Salary;

        await _context.SaveChangesAsync();
        return existingEmployee;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}