using EmployeeManager.Domain.Models;
using EmployeeManager.Infrastructure.DBConfiguration.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        async Task<int> IEmployeeRepository.AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        async Task<int> IEmployeeRepository.DeleteAsync(int id)
        {
            int result = 0;

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                result = await _context.SaveChangesAsync();
            }

            return result;
        }

        async Task<Employee> IEmployeeRepository.GetAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task<List<Employee>> IEmployeeRepository.GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        async Task IEmployeeRepository.UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
