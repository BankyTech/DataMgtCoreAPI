using Dapper;
using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Data.CommandType;
using DataManagement.Repository.Interfaces;
using System.Data;

namespace DataManagement.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public bool AddUser(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);

                SqlMapper.Execute(con, "AddUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to add user", ex);
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                if (userId <= 0)
                    throw new ArgumentException("User ID must be greater than 0", nameof(userId));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                SqlMapper.Execute(con, "DeleteUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to delete user", ex);
            }
        }

        public IList<User> GetAllUser() => SqlMapper.Query<User>(con, "GetAllUsers", commandType: StoredProcedure).ToList();
        public User GetUserById(int userId)
        {
            try
            {
                if (userId <= 0)
                    throw new ArgumentException("User ID must be greater than 0", nameof(userId));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerID", userId);
                return SqlMapper.Query<User>(con, "GetUserById", parameters, commandType: StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to get user by ID", ex);
            }
        }


        public bool UpdateUser(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", user.UserId);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);

                SqlMapper.Execute(con, "UpdateUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // Log the actual exception details in a real application
                throw new Exception("Failed to update user", ex);
            }
        }

        public void InsertMultipleUsers()
        {
            object myObj = new[] {
                new { name = "B Narayan", email = "bnarayan.sharma@outlook.com" },
                new { name = "Manish Sharma", email = "manish.sharma@outlook.com" },
                new { name = "Rohit Kumar", email = "rohit.kumar@outlook.com" }};

            con.Execute(@"insert Users(UserName, UserEmail) values (@name, @email)", myObj);
        }

        (List<Customer> customers, List<User> users) GetUsersAndCustomers()
        {
            using (var multi = con.QueryMultiple("select * from Customers;select * from Users"))
            {
                var customers = multi.Read<Customer>().ToList();
                var users = multi.Read<User>().ToList();
                return (customers, users);
            }
        }

    }
}
