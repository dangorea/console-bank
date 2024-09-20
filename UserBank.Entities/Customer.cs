﻿using Bank.Exceptions;
using System;
using UserBank.Entities.Contracts;

namespace UserBank.Entities
{
    /// <summary>
    /// Represents customer of the bank
    /// </summary>
    public class Customer : ICustomer, ICloneable
    {
        #region Private Fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion

        #region Public Properties
        /// <summary>
        /// GUID of Customer for Unique identification
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }

        /// <summary>
        /// Auto-generated code number of the customer 
        /// </summary>
        public long CustomerCode
        {
            get => _customerCode;
            set
            {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code should be positiv only");
                }
            }
        }

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (value.Length < 40 && !string.IsNullOrEmpty(value))
                {
                    _customerName = value;
                }
                else
                {
                    throw new CustomerException("Customer name should not be a nulland less than 40 characters");
                }
            }
        }

        /// <summary>
        /// Address of the customer
        /// </summary>
        public string Address { get => _address; set => _address = value; }

        /// <summary>
        /// Landmark of the customer's address
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }

        /// <summary>
        /// City of the customer
        /// </summary>
        public string City { get => _city; set => _city = value; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        public string Country { get => _country; set => _country = value; }

        /// <summary>
        /// 10-digit Mobile number of the customer
        /// </summary>
        public string Mobile
        {
            get => _mobile;
            set
            {
                if (value.Length == 10)
                {
                    _mobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile number should be a 10-digit number");
                }
            }
        }
        #endregion

        #region Methods
        public object Clone()
        {
            return new Customer()
            {
                CustomerID = this.CustomerID,
                CustomerCode = this.CustomerCode,
                CustomerName = this.CustomerName,
                Address = this.Address,
                Landmark = this.Landmark,
                Country = this.Country,
                City = this.City,
                Mobile = this.Mobile,
            };
        }
        #endregion
    }
}
