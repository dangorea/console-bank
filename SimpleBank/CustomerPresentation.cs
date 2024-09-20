using Bank.BusinessLogicLayer;
using Bank.BusinessLogicLayer.BALContracts;
using System;
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
                Console.WriteLine("\n********ADD CUSTOMER********");

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
                Console.WriteLine(newGuid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
