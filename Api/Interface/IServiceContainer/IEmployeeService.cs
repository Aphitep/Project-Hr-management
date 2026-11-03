using Api.Dtos;
using Api.Models;

namespace Api.IServices;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(int id);
    Task<Employee> CreateEmployeeAsync(CreateEmployeesDto employee);
    Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeesDto updatedEmployee);
    Task<bool> DeleteEmployeeAsync(int id);
}