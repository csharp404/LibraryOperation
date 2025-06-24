using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOperation.Application.Dtos.User
{
    public class UpdateProfileDto
    {
        public string? Name { set; get; }
        public string? Email { set; get; }
        public string? Phone { set; get; }

        public string Password { set; get; }
    }
}
