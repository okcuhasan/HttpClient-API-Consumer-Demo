using HttpClientDemoC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientDemoC_.Services
{
    public class CustomerService
    {
        public async Task<List<Customer>> GetCustomersAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7153/api/Customer");
            responseMessage.EnsureSuccessStatusCode();
            string content = await responseMessage.Content.ReadAsStringAsync();

            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(content);

            return customers;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = $"https://localhost:7153/api/Customer/{id}";

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            responseMessage.EnsureSuccessStatusCode();
            string content = await responseMessage.Content.ReadAsStringAsync();
            Customer customer = JsonSerializer.Deserialize<Customer>(content);

            return customer;
        }

        public async Task<List<Customer>> AddCustomerAsync(Customer customer)
        {
            HttpClient client = new HttpClient();
            string customerValue = JsonSerializer.Serialize(customer);
            StringContent stringContent = new StringContent(customerValue, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7153/api/Customer/CustomerCreate", stringContent);
            responseMessage.EnsureSuccessStatusCode();
            string content = await responseMessage.Content.ReadAsStringAsync();

            List<Customer> customerDb = JsonSerializer.Deserialize<List<Customer>>(content);

            return customerDb;
        }

        public async Task<List<Customer>> UpdateCustomerAsync(Customer customer)
        {
            HttpClient client = new HttpClient();
            string customerValue = JsonSerializer.Serialize(customer);
            StringContent stringContent = new StringContent(customerValue, Encoding.UTF8 , "application/json");
            HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7153/api/Customer/CustomerUpdate", stringContent);
            responseMessage.EnsureSuccessStatusCode();
            string content = await responseMessage.Content.ReadAsStringAsync();

            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(content);

            return customers;
        }

        public async Task<List<Customer>> RemoveCustomerAsync(int id)
        {
            HttpClient client = new HttpClient();
            string url = $"https://localhost:7153/api/Customer/{id}";

            HttpResponseMessage responseMessage = await client.DeleteAsync(url);
            responseMessage.EnsureSuccessStatusCode();
            string content = await responseMessage.Content.ReadAsStringAsync();

            List<Customer> customer = JsonSerializer.Deserialize<List<Customer>>(content);

            return customer;
        }
    }
}
