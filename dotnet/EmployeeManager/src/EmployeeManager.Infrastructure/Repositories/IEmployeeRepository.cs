using EmployeeManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee> GetAsync(int id);

        Task<int> AddAsync(Employee employee);

        Task<int> DeleteAsync(int id);

        Task UpdateAsync(Employee employee);
    }
}
