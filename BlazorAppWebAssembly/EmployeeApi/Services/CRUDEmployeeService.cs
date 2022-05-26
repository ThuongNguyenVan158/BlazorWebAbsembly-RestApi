using WebApp.Model.Dtos;
using EmployeeApi.Data;
using EmployeeApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Services
{
    public interface ICRUDEmployeeService
    {
        Task<List<EmployeeDto>> GetAsync();
        Task<EmployeeDto?> GetAsync(Guid id);
        Task CreateAsync(EmployeeDto newEmployee);
        Task UpdateAsync(Guid id, EmployeeDto updatednewEmployee);
        Task RemoveAsync(Guid id);
    }
    public class CRUDEmployeeService : ICRUDEmployeeService
    {
        private readonly EmployeeDbContext _context;
        public CRUDEmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeDto>> GetAsync()
        {
            //var listEmployee = _context.Employee.ToList();
            var listEmployee = await(from x in _context.Employee
                                select new EmployeeDto()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    BirthDate = x.BirthDate,
                                    Email = x.Email,
                                    Phone = x.Phone,
                                    TimeStartWork = x.TimeStartWork
                                }
                               ).ToListAsync();
            return listEmployee;
        }

        public async Task<EmployeeDto?> GetAsync(Guid id)
        {
            var employee = await (from x in _context.Employee
                                  where x.Id == id
                                  select new EmployeeDto()
                                  {
                                      Id = x.Id,
                                      Name = x.Name,
                                      BirthDate = x.BirthDate,
                                      Phone = x.Phone,
                                      Email = x.Email,
                                      TimeStartWork = x.TimeStartWork
                                  }).FirstOrDefaultAsync();
            return employee;
        }
        public async Task CreateAsync(EmployeeDto newEmployee)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = newEmployee.Name,
                BirthDate = newEmployee.BirthDate.ToUniversalTime(),
                Email = newEmployee.Email,
                Phone = newEmployee.Phone,
                TimeStartWork = newEmployee.TimeStartWork.ToUniversalTime()
            };
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, EmployeeDto updatednewEmployee)
        {
            var employee = await (from x in _context.Employee
                                  where x.Id == id
                                  select x).FirstOrDefaultAsync();
            if (employee != null)
            {
                //employee.BirthDate = updatednewEmployee.BirthDate;
                employee.Name = updatednewEmployee.Name;
                employee.Email = updatednewEmployee.Email;
                employee.Phone = updatednewEmployee.Phone;
            }
            await _context.SaveChangesAsync();
        }


        public async Task RemoveAsync(Guid id)
        {
            var employee = await (from x in _context.Employee
                                  where x.Id == id
                                  select x).FirstOrDefaultAsync();
            if (employee != null)
                _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
