﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class UserLoginVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
