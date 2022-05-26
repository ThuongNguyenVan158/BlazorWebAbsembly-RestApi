using WebApp.Model.Dtos;

namespace BlazorAppWebAssembly.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployee();
        Task<EmployeeDto> GetEmployeeById(Guid id);
        Task<EmployeeDto> AddItem(EmployeeDto employee);
        Task<EmployeeDto> DeleteItem(Guid id);
    }
}
