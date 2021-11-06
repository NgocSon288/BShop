using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels.AppUsers.Validators
{
    public class AppUserRegisterRequestValidator : AbstractValidator<AppUserRegisterRequest>
    {
        public AppUserRegisterRequestValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Tên không hợp lệ");

            RuleFor(x => x.Dob).NotEmpty().WithMessage("Ngày sinh không hợp lệ")
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Ngày sinh không hợp lệ");
             

            RuleFor(x => x.Address).NotEmpty().WithMessage("Địa chỉ không hợp lệ")
                .MaximumLength(500).WithMessage("Địa chỉ không hợp lệ");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không hợp lệ")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email không đúng định dạng");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tài khoản không hợp lệ");
            
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Mật khẩu không hợp lệ")
                .MinimumLength(3).WithMessage("Mật khẩu phải có ít nhật 3 ký tự");
             
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.PassWord != request.PassWordConfirm)
                {
                    context.AddFailure("Xác nhận mật khẩu không hợp lệ");
                }
            });

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Avatar == null || request.Avatar.Length <=0)
                {
                    context.AddFailure("Ảnh đại diện không hợp lệ");
                }
            });
        }
    }
}