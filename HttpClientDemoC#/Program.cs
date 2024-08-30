using HttpClientDemoC_.Models;
using HttpClientDemoC_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemoC_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CustomerService customerService = new CustomerService();
            // GetAll
            Console.WriteLine("Fetching all customers...");
            List<Customer> customers = await customerService.GetCustomersAsync();
            foreach(Customer customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName}, Last Name: {customer.LastName}, Place: {customer.Place}");
            }
            // GetById
            Console.WriteLine("\n Fetching customer with ID...");
            string value = Console.ReadLine();
            int intValue = Convert.ToInt16(value);
            Customer customerById = await customerService.GetCustomerAsync(intValue);
            Console.WriteLine($"ID: {customerById.Id}, Name: {customerById.FirstName}, Last Name: {customerById.LastName}, Place: {customerById.Place}");
            // Create
            Console.WriteLine("\n Adding a new customer...");
            Console.WriteLine("\n Enter customer first name...");
            string firstName = Console.ReadLine();
            Console.WriteLine("\n Enter customer last name...");
            string lastName = Console.ReadLine();
            Console.WriteLine("\n Enter customer place...");
            string place = Console.ReadLine();
            List<Customer> customerList = await customerService.AddCustomerAsync(new Customer { FirstName = firstName, LastName = lastName, Place = place});
            foreach (Customer customer in customerList)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName}, Last Name: {customer.LastName}, Place: {customer.Place}");
            }
            // Update
            Console.WriteLine("\n Updating customer with ID...");
            Console.WriteLine("\n Enter customer ID...");
            string customerId = Console.ReadLine();
            int customerIdInt = Convert.ToInt16(customerId);
            Console.WriteLine("\n Enter customer first name...");
            string firstNameUpdate = Console.ReadLine();
            Console.WriteLine("\n Enter customer last name...");
            string lastNameUpdate = Console.ReadLine();
            Console.WriteLine("\n Enter customer place...");
            string placeUpdate = Console.ReadLine();
            List<Customer> customerListUpdate = await customerService.UpdateCustomerAsync(new Customer { Id = customerIdInt, FirstName = firstNameUpdate, LastName = lastNameUpdate, Place = placeUpdate });
            foreach (Customer customer in customerListUpdate)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName}, Last Name: {customer.LastName}, Place: {customer.Place}");
            }
            // Delete
            Console.WriteLine("\n Removing customer with ID...");
            Console.WriteLine("\n Enter customer ID...");
            string customerIdRemove = Console.ReadLine();
            int customerIdIntRemove = Convert.ToInt16(customerIdRemove);
            List<Customer> customersRemove = await customerService.RemoveCustomerAsync(customerIdIntRemove);
            foreach (Customer customer in customersRemove)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName}, Last Name: {customer.LastName}, Place: {customer.Place}");
            }
        }
    }
}