using Bank.BusinessLogicLayer.BALContracts;
using Bank.Configuration;
using Bank.DataAccessLayer;
using Bank.DataAccessLayer.DALContracts;
using Bank.Exceptions;
using System;
using System.Collections.Generic;
using UserBank.Entities;

namespace Bank.BusinessLogicLayer
{
    /// <summary>
    /// Represents customer business logic
    /// </summary>
    public class CustomersBusinessLogicLayer : ICustomerBusinessLogicLayer
    {
        #region Private Fields
        private ICustomerDataAccessLayer _customerDataAccessLayer;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initializes CustomersDataAccessLayer
        /// </summary>
        public CustomersBusinessLogicLayer()
        {
            _customerDataAccessLayer = new CustomersDataAccessLayer();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Private property that represents reference of CustomerDataAccessLayer
        /// </summary>
        private ICustomerDataAccessLayer CustomerDataAccessLayer
        {
            set => _customerDataAccessLayer = value;
            get => _customerDataAccessLayer;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                return CustomerDataAccessLayer.GetCustomers();

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
        /// Returns a set of customer that matches with specified criteria
        /// </summary>
        /// <param name="customer">Lambda expresion that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> customer)
        {
            try
            {
                return CustomerDataAccessLayer.GetCustomersByCondition(customer);

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
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Return true, that indicates the customer is added successfuly</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                List<Customer> allCustomers = CustomerDataAccessLayer.GetCustomers();
                long maxCustNo = 0;

                foreach (Customer client in allCustomers)
                {
                    if (client.CustomerCode > maxCustNo)
                    {
                        maxCustNo = client.CustomerCode;
                    }
                }

                // generate new customers Number
                if (allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustNo + 1;
                }
                else
                {
                    customer.CustomerCode = Settings.BaseCustomerNo + 1;
                }


                return CustomerDataAccessLayer.AddCustomer(customer);

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
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update</param>
        /// <returns>Returns true, that indicates the customer is updated</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return CustomerDataAccessLayer.UpdateCustomer(customer);
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
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns>Returns true, that indicates the customer is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                return CustomerDataAccessLayer.DeleteCustomer(customerId);
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
