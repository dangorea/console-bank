using Bank.BusinessLogicLayer;
using Bank.BusinessLogicLayer.BALContracts;
using System;
using System.Collections.Generic;
using UserBank.Entities;

namespace SimpleBank
{
    static class CustomerPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                // create an object of Customer
                Customer customer = new Customer();

                // read all details from the user
                Console.Clear();
                Console.WriteLine("********ADD CUSTOMER********");

                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();

                Console.Write("Address: ");
                customer.Address = Console.ReadLine();

                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();

                Console.Write("City: ");
                customer.City = Console.ReadLine();

                Console.Write("Country: ");
                customer.Country = Console.ReadLine();

                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customerBusinessLogicLayer.AddCustomer(customer);

                List<Customer> matchingCustomers = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newGuid);

                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("\nNew Customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer added.\n");
                }
                else
                {
                    Console.WriteLine("\nCustomer Not Added\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.WriteLine(ex.GetType() + "\n");
            }
        }

        internal static void ViewCustomers()
        {
            try
            {
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomersBusinessLogicLayer();
                List<Customer> allCustomers = customerBusinessLogicLayer.GetCustomers();

                Console.Clear();
                Console.WriteLine("********ALL CUSTOMERS********");
                allCustomers.ForEach((customer) =>
                {
                    Console.WriteLine("\nCustomer Code: " + customer.CustomerCode);
                    Console.WriteLine("Customer Name: " + customer.CustomerName);
                    Console.WriteLine("Landmark: " + customer.Landmark);
                    Console.WriteLine("Country: " + customer.Country);
                    Console.WriteLine("City: " + customer.City);
                    Console.WriteLine("Address: " + customer.Address);
                    Console.WriteLine("Mobile: " + customer.Mobile);
                });
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.WriteLine(ex.GetType() + "\n");
            }
        }
    }
}
