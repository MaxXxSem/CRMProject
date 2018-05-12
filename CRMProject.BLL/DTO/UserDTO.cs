using System;
using System.Collections.Generic;

namespace CRMProject.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string PhotoPath { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
