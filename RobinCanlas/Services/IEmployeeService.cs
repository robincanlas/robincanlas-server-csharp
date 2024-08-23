using RobinCanlas.Models;

namespace RobinCanlas.Services
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);
        Task<Employee> GetEmployee(int key);
        Task<List<Employee>> GetEmployeeList();
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int key);
    }
}
