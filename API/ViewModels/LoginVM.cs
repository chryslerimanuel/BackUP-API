﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        //public IEnumerable<string> Role { get; set; }

        public string Role { get; set; }

    }
}
