using Api.DB;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Service;

class EmployeeService
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

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        employee.CreatedAt = DateTime.UtcNow;
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateEmployeeAsync(int id, Employee updatedEmployee)
    {
        var existingEmployee = await _context.Employees.FindAsync(id);
        if (existingEmployee == null)
        {
            return null;
        }

        existingEmployee.FirstName = updatedEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName;
        existingEmployee.Email = updatedEmployee.Email;
        existingEmployee.Salary = updatedEmployee.Salary;

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