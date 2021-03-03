﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_Account")]
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "This field is required")]
        public string NIK { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        
        [JsonIgnore]
        public virtual Person Person { get; set; }

        [JsonIgnore]
        public virtual Profiling Profiling { get; set; }

        [JsonIgnore]
        public virtual List<RoleAccount> RoleAccounts { get; set; } = new List<RoleAccount>();
    }
}
