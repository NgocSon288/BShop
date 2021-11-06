using Microsoft.AspNetCore.Identity;
using EShop.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Data.EF;

namespace EShop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IAuditable
    {
        public string FullName { get; set; }

        public DateTime Dob { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; } 

        public DateTime? CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdateBy { get; set; }

        public bool? IsDeleted { get; set; }

        public List<Order> Orders { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
