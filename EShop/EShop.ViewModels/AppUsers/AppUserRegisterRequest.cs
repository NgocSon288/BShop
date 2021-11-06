using Microsoft.AspNetCore.Http;
using EShop.ViewModels.Enums;
using System;

namespace EShop.ViewModels.AppUsers
{
    public class AppUserRegisterRequest
    {
        public string FullName { get; set; }

        public DateTime Dob { get; set; }

        public IFormFile Avatar { get; set; }

        public string Address { get; set; }

        public Gender? Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string PassWordConfirm { get; set; }
    }
}