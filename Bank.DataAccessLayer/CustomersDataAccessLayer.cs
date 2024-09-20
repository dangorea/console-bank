using Bank.DataAccessLayer.DALContracts;
using Bank.Exceptions;
using System;
using System.Collections.Generic;
using UserBank.Entities;

namespace Bank.DataAccessLayer
{
    /// <summary>
    /// Represents DAL for bank customer
    /// </summary>
    public class CustomersDataAccessLayer : ICustomerDataAccessLayer
    {

        #region Fields 
        private List<Customer> _customers;
        #endregion

        #region Constructors
        public CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Properties
        /// <summary>
        ///  Represents source customer collection
        /// </summary>
        private List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customer list</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customersList = new List<Customer>();
                Customers.ForEach(customer => customersList.Add(customer.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Return list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                List<Customer> customersList = new List<Customer>();

                List<Customer> filteredCustomers = customersList.FindAll(predicate);

                Customers.ForEach(customer => filteredCustomers.Add(customer.Clone() as Customer));

                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Adds a new customer to the existing list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Return GUID of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                customer.CustomerID = Guid.NewGuid();

                Customers.Add(customer);

                return customer.CustomerID;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an existing customer details
        /// </summary>
        /// <param name="customer">Customer object with updated details</param>
        /// <returns>Determines wheter the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                // update all details of customer
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true;
                }

                return false;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delets an existing customer base on CustomerID
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>Indicates wheater the customer is deleted or not</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                if (Customers.RemoveAll(item => item.CustomerID == customerId) > 0)
                {
                    return true;
                }

                return false;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
