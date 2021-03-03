//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using API.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TokenController : ControllerBase
//    {
//        private IConfiguration _config;

//        public TokenController(IConfiguration config)
//        {
//            _config = config;
//        }

//        // mendapatkan random token
//        [HttpGet]
//        public string GetRandomToken()
//        {
//            var jwt = new JwtServices(_config);
//            var token = jwt.GenerateSecurityToken("fake@email.com");
//            return token;
//        }
//    }
//}