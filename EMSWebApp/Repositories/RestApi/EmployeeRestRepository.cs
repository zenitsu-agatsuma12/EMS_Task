using EMSWebApp.Models;
using EMSWebApp.ViewModel;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EMSWebApp.Repositories.Api
{
    public class EmployeeRestRepository : IEmployeeRepository
    {
        string baseURL = "http://localhost:5176/api";
        HttpClient httpClient = new HttpClient();

        public EmployeeRestRepository()
        {
        }
        public EmployeeViewModel AddEmployees(EmployeeViewModel newEmployee)
        {
            
            /* var newTodoAsString = JsonConvert.SerializeObject(newEmployee);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Employee", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var todo = JsonConvert.DeserializeObject<Employee>(content);
                return todo;
            }

            return null; */

            string data = JsonConvert.SerializeObject(newEmployee);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var queryParameters = new Dictionary<string, string>
            {
                { "First_Name", newEmployee.First_Name },
                { "Last_Name", newEmployee.Last_Name },
                { "Middle_Name", newEmployee.Middle_Name },
                { "Address", newEmployee.Address },
                { "DOB", newEmployee.DOB }
            };

            string queryString = string.Join("&", queryParameters.Select(x => $"{x.Key}={x.Value}"));
            string fullURL = $"{baseURL}/Employee?{queryString}";

            var response = httpClient.PostAsync(fullURL, content).Result;
            if (response.IsSuccessStatusCode)
            {
                 /* var responseContent = response.Content.ReadAsStringAsync().Result;
                 EmployeeViewModel employee = JsonConvert.DeserializeObject<EmployeeViewModel>(responseContent);
                 return employee; */
            }
            return null;
        }


        public Employee DeleteEmployee(int id)
        {
            var response = httpClient.DeleteAsync($"{baseURL}/Employee/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var deletedEmployee = JsonConvert.DeserializeObject<Employee>(data);
                return deletedEmployee;
            }

            return null;
        }


        public Employee GetEmployeeById(int id)
        {
            var url = $"{baseURL}/Employee/{id}";

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var employee = JsonConvert.DeserializeObject<Employee>(data);
                return employee;
            }

            return null;
        }


        public List<Employee> GetEmployees()
        {
            var response = httpClient.GetAsync(baseURL + "/Employee").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(data);
                return emp;
            }
            return null; 
        }

        public Employee UpdateEmployee(int id, Employee newEmployee)
        {
            var url = $"{baseURL}/Employee?Id={id}&First_Name={newEmployee.First_Name}&Last_Name={newEmployee.Last_Name}&Middle_Name={newEmployee.Middle_Name}&Address={newEmployee.Address}&DOB={newEmployee.DOB}";

            var response = httpClient.PutAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var updatedEmployee = JsonConvert.DeserializeObject<Employee>(data);
                return updatedEmployee;
            }

            return null;
        }



    }
}
