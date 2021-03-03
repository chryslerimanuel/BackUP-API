﻿using API.Context;
using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;

        public IConfiguration _configuration;

        readonly DynamicParameters parameters = new DynamicParameters();

        public AccountRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.myContext = myContext;
            _configuration = configuration;
        }

        //public LoginVM Login(string email, string password)
        //{
        //    var model = myContext.Accounts
        //           .Include(p => p.Person)
        //           .Include(ra => ra.RoleAccounts)
        //           .ToList();

        //    var checkLogin = model.FirstOrDefault(x => x.Person.Email == email && x.Password == password);

        //    if (checkLogin != null)
        //    {
        //        var getRole = myContext.RoleAccounts
        //                    .Include(r => r.Role)
        //                    .FirstOrDefault(x => x.Account_NIK == checkLogin.NIK);

        //        var getRole = myContext.RoleAccounts
        //                    .Include(r => r.Role)
        //                    .Where(x => x.Account_NIK == checkLogin.NIK).ToList();

        //        LoginVM login = new LoginVM
        //        {
        //            Email = checkLogin.Person.Email,
        //            FullName = checkLogin.Person.FirstName + " " + checkLogin.Person.LastName,

        //            Role = getRole.Role.Name

        //            Role = myContext.RoleAccounts
        //                    .Join(myContext.Roles,
        //                    roleAccount => roleAccount.Role_Id,
        //                    role => role.Id,
        //                    (roleAccount, role) => new
        //                    {
        //                        NIK = roleAccount.Account_NIK,
        //                        RoleName = role.Name
        //                    })
        //                    .Where(r => r.NIK == checkLogin.NIK)
        //                    .Select(r => r.RoleName)
        //        };
        //        return login;
        //    }
        //    return null;
        //}  

        public LoginVM Login(LoginVM loginVM)
        {
            LoginVM result = null;

            var person = myContext.Persons.Where(p => p.Email == loginVM.Email).SingleOrDefault();

            if (person != null)
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("MyContext"));
                var spName = "SP_LoginAccount";
                parameters.Add("@email", loginVM.Email);
                parameters.Add("@password", loginVM.Password);
                result = db.Query<LoginVM>(spName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }

        public int Register(RegisterVM registerVM)
        {
            var model = myContext.Accounts
                   .Include(p => p.Person)
                   .Include(ra => ra.RoleAccounts)
                   .ToList();

            var checkEmail = myContext.Persons
                           .SingleOrDefault(e => e.Email.Equals(registerVM.Email));

            if (checkEmail == null)
            {
                Person person = new Person();
                Account account = new Account();

                person.NIK = registerVM.NIK;
                person.FirstName = registerVM.FirstName;
                person.LastName = registerVM.LastName;
                person.BirthDate = registerVM.BirthDate;
                person.Email = registerVM.Email;

                account.Password = registerVM.Password;

                myContext.Persons.Add(person);
                myContext.Accounts.Add(account);

                var result = myContext.SaveChanges();

                return result;
            }
            return 0;
        }
    }
}
