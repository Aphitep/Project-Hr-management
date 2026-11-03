namespace Api.Service;

public static class DependenceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<EmployeeService>();
        services.AddScoped<DepartmentService>();

        return services;
    }
}