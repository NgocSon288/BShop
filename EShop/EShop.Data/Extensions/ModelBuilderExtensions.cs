using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EShop.Data.Entities;
using EShop.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Roles
            var roleAdminId = new Guid("647109ED-63AA-4DFC-A219-3A551D353AF1");
            var roleMemberId = new Guid("44D86938-D29E-48CF-8DB3-4144AA15385A");
            modelBuilder.Entity<AppRole>()
                .HasData(new AppRole
                {
                    Id = roleAdminId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Người quản trị, có quyền quản lý hệ thống"
                }, new AppRole
                {
                    Id = roleMemberId,
                    Name = "member",
                    NormalizedName = "member",
                    Description = "Thành viên có đã đăng nhập"
                });


            // AppUsers
            var adminId = new Guid("F9CE118D-0AC9-4A9F-A20F-38B784C6B9DD");
            var memberId = new Guid("8C596113-AA13-4CD3-8965-E3BE8DC0626B");
            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>()
                .HasData(new AppUser
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "seo169401@gmail.com",
                    NormalizedEmail = "seo169401@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    SecurityStamp = string.Empty,
                    FullName = "Tôi là Người quản trị",
                    Dob = new DateTime(2000, 01, 01),
                    Avatar = "ImageUploads/admin.jpg",
                    Address = "TP Hồ Chí Minh",
                    Gender = Gender.Male,
                    CreatedAt = new DateTime(2021, 10, 1),
                    CreatedBy = "",
                    UpdatedAt = new DateTime(2021, 10, 1),
                    UpdateBy = "",
                    IsDeleted = false
                }, new AppUser
                {
                    Id = memberId,
                    UserName = "member",
                    NormalizedUserName = "member",
                    Email = "seo169403@gmail.com",
                    NormalizedEmail = "seo169403@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    SecurityStamp = string.Empty,
                    FullName = "Tôi là Thành viên",
                    Dob = new DateTime(2020, 01, 01),
                    Avatar = "ImageUploads/member.jpg",
                    Address = "Đà Nẵng",
                    Gender = Gender.Female,
                    CreatedAt = new DateTime(2021, 10, 1),
                    CreatedBy = "",
                    UpdatedAt = new DateTime(2021, 10, 1),
                    UpdateBy = "",
                    IsDeleted = false
                });


            //  AppUserRoles
            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasData(new IdentityUserRole<Guid>
                {
                    RoleId = roleAdminId,
                    UserId = adminId
                }, new IdentityUserRole<Guid>
                {
                    RoleId = roleMemberId,
                    UserId = memberId
                });


            // Categories
            modelBuilder.Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Điện thoại",
                    Description = "Điện thoại xịn",
                    CreatedAt = new DateTime(2021, 05, 11),
                    CreatedBy = "",
                    UpdatedAt = new DateTime(2021, 05, 11),
                    UpdateBy = "",
                    IsDeleted = false
                }, new Category()
                {
                    Id = 2,
                    Name = "Máy tính bảng",
                    Description = "Máy tính bảng xịn",
                    CreatedAt = new DateTime(2021, 05, 11),
                    CreatedBy = "",
                    UpdatedAt = new DateTime(2021, 05, 11),
                    UpdateBy = "",
                    IsDeleted = false
                }, new Category()
                {
                    Id = 3,
                    Name = "Laptop",
                    Description = "Laptop xịn",
                    CreatedAt = new DateTime(2021, 05, 11),
                    CreatedBy = "",
                    UpdatedAt = new DateTime(2021, 05, 11),
                    UpdateBy = "",
                    IsDeleted = false
                }, new Category()
                {
                    Id = 4,
                    Name = "SmartWatch",
                    Description = "SmartWatch xịn",
                    CreatedAt = new DateTime(2021, 05, 11),
                    CreatedBy = "",
                    UpdatedAt = new DateTime(2021, 05, 11),
                    UpdateBy = "",
                    IsDeleted = false
                });

            // PaymentMethods
            modelBuilder.Entity<PaymentMethod>()
                .HasData(new PaymentMethod()
                {
                    Id = 1,
                    Name = "Thanh toán khi nhận hàng",
                    Description = "Thanh toán khi nhận hàng"
                }, new PaymentMethod()
                {
                    Id = 2,
                    Name = "Thanh toán bằng thẻ tín dụng/ ghi nợ",
                    Description = "Thanh toán bằng thẻ tín dụng/ ghi nợ"
                }, new PaymentMethod()
                {
                    Id = 3,
                    Name = "Thanh toán bằng Internet Banking",
                    Description = "Thanh toán bằng thẻ ATM nội địa có Internet Banking"
                }, new PaymentMethod()
                {
                    Id = 4,
                    Name = "hanh toán bằng ví eM",
                    Description = "hanh toán bằng ví eM"
                }, new PaymentMethod()
                {
                    Id = 5,
                    Name = "Thanh toán bằng ví Momo",
                    Description = "Thanh toán bằng ví Momo"
                });

            // OrderStatuses
            modelBuilder.Entity<OrderStatus>()
                .HasData(new OrderStatus()
                {
                    Id = 1,
                    Name = "Chờ xác nhận",
                    Description = "Chờ xác nhận",
                    Color = "info   "
                }, new OrderStatus()
                {
                    Id = 2,
                    Name = "Chờ lấy hàng",
                    Description = "Chờ lấy hàng",
                    Color = "primary"
                }, new OrderStatus()
                {
                    Id = 3,
                    Name = "Đang giao",
                    Description = "Đang giao",
                    Color = "secondary"
                }, new OrderStatus()
                {
                    Id = 4,
                    Name = "Đã giao",
                    Description = "Đã giao",
                    Color = "success"
                }, new OrderStatus()
                {
                    Id = 5,
                    Name = "Đã hủy",
                    Description = "Đã hủy",
                    Color = "warning"
                }, new OrderStatus()
                {
                    Id = 6,
                    Name = "Trả hàng",
                    Description = "Trả hàng",
                    Color = "dark"
                });
        }
    }
}
