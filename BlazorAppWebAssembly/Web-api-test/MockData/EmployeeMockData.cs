using EmployeeApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.Dtos;

namespace Web_api_test.MockData
{
    public class EmployeeMockData
    {
        public static List<EmployeeDto> GetListEmployee()
        {
            return new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Need To Go Shopping",
                    BirthDate = DateTime.Now,
                    Email = "a@gmail.com",
                    Phone = "022434",
                    TimeStartWork = DateTime.Now
                },
                new EmployeeDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Need To Go Shopping",
                    BirthDate = DateTime.Now,
                    Email = "b@gmail.com",
                    Phone = "022434",
                    TimeStartWork = DateTime.Now
                },
                new EmployeeDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Need To Go Shopping",
                    BirthDate = DateTime.Now,
                    Email = "c@gmail.com",
                    Phone = "022434",
                    TimeStartWork = DateTime.Now
                }
            };
        }
        public static List<Employee> GetListEmployeeDb()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Need To Go Shopping",
                    BirthDate = DateTime.Now,
                    Email = "a@gmail.com",
                    Phone = "022434",
                    TimeStartWork = DateTime.Now
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Need To Go Shopping",
                    BirthDate = DateTime.Now,
                    Email = "b@gmail.com",
                    Phone = "022434",
                    TimeStartWork = DateTime.Now
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Need To Go Shopping",
                    BirthDate = DateTime.Now,
                    Email = "c@gmail.com",
                    Phone = "022434",
                    TimeStartWork = DateTime.Now
                }
            };
        }
        public static EmployeeDto NewEmployee()
        {
            return new EmployeeDto()
            {
                Id = Guid.NewGuid(),
                Name = "Need To Go Shopping",
                BirthDate = DateTime.Now,
                Email = "c@gmail.com",
                Phone = "022434",
                TimeStartWork = DateTime.Now
            };
        }
    }
}
