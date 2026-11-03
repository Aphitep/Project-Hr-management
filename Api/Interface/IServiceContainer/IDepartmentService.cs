using Api.Dtos;
using Api.Models;

namespace Api.IServices;

public interface IDepartmentService
{
    Task<List<Department>> GetAllDepartmentsAsync();
    Task<Department?> GetDepartmentAsync(int id);
    Task<Department> CreateDepartmentAsync(CreateDepartmentDto departmentDto);
    Task<Department?> UpdateDepartmentAsync(int id, CreateDepartmentDto updatedDepartment);
    Task<bool> DeleteDepartmentAsync(int id);
}