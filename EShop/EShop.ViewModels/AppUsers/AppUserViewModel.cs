using EShop.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels.AppUsers
{
    public class AppUserViewModel
    {
        public string FullName { get; set; }

        public DateTime Dob { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
