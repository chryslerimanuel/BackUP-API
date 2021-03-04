using API.Context;
using API.Models;
using API.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public IConfiguration _configuration;
        readonly DynamicParameters parameters = new DynamicParameters();

        public AccountRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public LoginVM Login(LoginVM loginVM)
        {
            GeneralDapperRepository<LoginVM> generalDapper = new GeneralDapperRepository<LoginVM>(_configuration);
          
            var spName = "SP_LoginAccount";
            parameters.Add("@email", loginVM.Email);
            parameters.Add("@password", loginVM.Password);
            var result = generalDapper.ExecSPList(spName, parameters);

            LoginVM hasil = new LoginVM();
            hasil.Email = result.FirstOrDefault().Email;
            hasil.FullName = result.FirstOrDefault().FullName;
            hasil.Roles = result.Select(x => x.RoleName); //select semua role dari hasil 

            return hasil;
        }
    }
}