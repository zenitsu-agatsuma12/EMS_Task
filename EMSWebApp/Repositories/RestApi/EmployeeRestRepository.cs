using EMSWebApp.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EMSWebApp.Repositories.Api
{
    public class EmployeeRestRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;
       
        public EmployeeRestRepository(IConfiguration configs)
        {
            _httpClient = new HttpClient();
            _configs = configs;
            _httpClient.BaseAddress = new Uri("http://localhost:5176/api");
        }
        public async Task<Employee?> AddEmployees(Employee newEmployee)
        {
            var newTodoAsString = JsonConvert.SerializeObject(newEmployee);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Employee", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var todo = JsonConvert.DeserializeObject<Employee>(content);
                return todo;
            }

            return null;
        }

        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            /*var response = httpClient.GetAsync(baseURL + "/Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(data);
                return emp;
            }
            return null; */

            var response = await _httpClient.GetAsync("/Employee");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var emp = JsonConvert.DeserializeObject<List<Employee>>(content);
                return emp ?? new();
            }

            return new();
        }

        public Employee UpdateEmployee(int id, Employee newEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
