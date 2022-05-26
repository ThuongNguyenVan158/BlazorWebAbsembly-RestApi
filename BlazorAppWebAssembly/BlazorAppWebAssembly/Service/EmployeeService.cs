using WebApp.Model.Dtos;
using System.Net.Http.Json;

namespace BlazorAppWebAssembly.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployee()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return new List<EmployeeDto>();
                    return await response.Content.ReadFromJsonAsync<IEnumerable<EmployeeDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EmployeeDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
        public async Task<EmployeeDto> AddItem(EmployeeDto employee)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<EmployeeDto>("api/Employee", employee);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new EmployeeDto();
                    }

                    return await response.Content.ReadFromJsonAsync<EmployeeDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<EmployeeDto> DeleteItem(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<EmployeeDto>();
                }
                return new EmployeeDto();
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
