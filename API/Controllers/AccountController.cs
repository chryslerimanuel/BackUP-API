﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Base.Controller;
using API.Models;
using API.Repository.Data;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        private readonly IConfiguration _configuration;

        public AccountController(AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public ActionResult<Account> Login(LoginVM loginVM)
        {
            var data = accountRepository.Login(loginVM);

            if (data != null)
            {
                var jwt = new JwtServices(_configuration);
                var token = jwt.GenerateSecurityToken(data);

                return Ok(new { message = "Berhasil Login", token });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Gagal Login" });
            }
        }
    }
}