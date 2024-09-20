using System;
using System.Collections.Generic;
using UserBank.Entities;

namespace Bank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents customer business logic
    /// </summary>
    public interface ICustomerBusinessLogicLayer
    {

        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List of customers</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Returns a set of customer that matches with specified criteria
        /// </summary>
        /// <param name="customer">Lambda expresion that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> customer);

        /// <summary>
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Return true, that indicates the customer is added successfuly</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update</param>
        /// <returns>Returns true, that indicates the customer is updated</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>Returns true, that indicates the customer is deleted successfully</returns>
        bool DeleteCustomer(Guid customerId);
    }
}
