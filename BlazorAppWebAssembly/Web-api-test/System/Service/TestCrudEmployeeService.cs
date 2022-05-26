using EmployeeApi.Data;
using EmployeeApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web_api_test.MockData;
using Xunit;

namespace Web_api_test.System.Service
{
    public class TestCrudEmployeeService: IDisposable
    {
        private readonly EmployeeDbContext _context;
        public TestCrudEmployeeService()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new EmployeeDbContext(options);
            _context.Database.EnsureCreated();

        }
        [Fact]
        public async Task GetAsync_ReturnCollection()
        {
            //Arrange
            _context.Employee.AddRange(EmployeeMockData.GetListEmployeeDb());
            _context.SaveChanges();
            var sut = new CRUDEmployeeService(_context);
            //Act
            var result = await sut.GetAsync();
            //Assert
            Assert.Equal(result.Count(), EmployeeMockData.GetListEmployeeDb().Count());
        }
        [Fact]
        public async Task CreateAsync_AddNewEmployee()
        {
            /// Arrange
            var newTodo = EmployeeMockData.NewEmployee();
            _context.Employee.AddRange(EmployeeMockData.GetListEmployeeDb());
            _context.SaveChanges();

            var sut = new CRUDEmployeeService(_context);

            /// Act
            await sut.CreateAsync(newTodo);

            ///Assert
            int expectedRecordCount = (EmployeeMockData.GetListEmployeeDb().Count() + 1);
            Assert.Equal(_context.Employee.Count(), expectedRecordCount);
        }
        //[Fact]
        //public async Task RemoveAsync_RemoveEmployee()
        //{
        //    /// Arrange
        //    var employeeId = EmployeeMockData.GetListEmployeeDb().First().Id;
        //    _context.Employee.AddRange(EmployeeMockData.GetListEmployeeDb());
        //    _context.SaveChanges();

        //    var sut = new CRUDEmployeeService(_context);

        //    /// Act
        //    //await sut.RemoveAsync(employeeId);

        //    ///Assert
        //    int expectedRecordCount = (EmployeeMockData.GetListEmployeeDb().Count() - 1);
        //    //Assert.Equal(_context.Employee.Count(), 2);
        //    Assert.Equal(EmployeeMockData.GetListEmployeeDb().First().Id, employeeId);
        //}
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose(); 
        }

    }
}
