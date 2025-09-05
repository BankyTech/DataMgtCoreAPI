using System;
using System.Collections.Generic;
using System.Linq;
using DataManagement.Repository.Interfaces;
using DataManagement.Entities;
using Dapper;
using static System.Data.CommandType;

namespace DataManagement.Repository
{
    public class CustomerRepository:BaseRepository, IRepository<Customer>
    {
        public void Add(Customer entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@CustomerEmail", entity.CustomerEmail);
                parameters.Add("@CustomerMobile", entity.CustomerMobile);
                SqlMapper.Execute(con, "AddCustomer", param: parameters, commandType:StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to add customer", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Customer ID must be greater than 0", nameof(id));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", id);
                SqlMapper.Execute(con, "DeleteCustomer", param: parameters, commandType:StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to delete customer", ex);
            }
        }

        public IEnumerable<Customer> Get()
        {
            try
            {
                IList<Customer> customerList = SqlMapper.Query<Customer>(con, "GetAllCustomer", commandType:StoredProcedure).ToList();
                return customerList;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to get all customers", ex);
            }
        }

        public Customer Get(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Customer ID must be greater than 0", nameof(id));

                DynamicParameters parameters = new DynamicParameters();           
                parameters.Add("@CustomerID", id);
                return SqlMapper.Query<Customer>(
                    con,
                    "GetCustomerById",
                    parameters,
                    commandType: StoredProcedure
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to get customer by ID", ex);
            }
        }

        public void Update(Customer entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerID", entity.CustomerId);
                parameters.Add("@CustomerName", entity.CustomerName);
                parameters.Add("@CustomerEmail", entity.CustomerEmail);
                parameters.Add("@CustomerMobile", entity.CustomerMobile);
                SqlMapper.Execute(con, "UpdateCustomer", param: parameters, commandType: StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to update customer", ex);
            }
        }
    }
}
