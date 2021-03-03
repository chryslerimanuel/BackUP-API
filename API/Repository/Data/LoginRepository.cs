using API.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class LoginRepository : GeneralDapperRepository<LoginVM, DynamicParameters>
    {
        public LoginRepository(IConfiguration config) : base(config)
        {

        }
    }
}
