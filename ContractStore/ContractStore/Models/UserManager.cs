using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractStore.Models
{
    public static class UserManager
    {
        public static User ActiveUser { get; set; } = new User() { Name = ""};
    }
}
