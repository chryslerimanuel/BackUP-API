using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tb_M_RoleAccount")]
    public class RoleAccount
    {
        public int Role_Id { get; set; }

        [JsonIgnore]
        public virtual Role Role { get; set; }

        public string Account_NIK { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
