using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.UserModel
{
    public class UserModle
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
}
