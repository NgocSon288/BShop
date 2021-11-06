using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 766, DateTimeKind.Local).AddTicks(7850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 555, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 766, DateTimeKind.Local).AddTicks(7121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 555, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 758, DateTimeKind.Local).AddTicks(4896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 547, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 758, DateTimeKind.Local).AddTicks(4194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 547, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 755, DateTimeKind.Local).AddTicks(8927),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 544, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 755, DateTimeKind.Local).AddTicks(8169),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 544, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 753, DateTimeKind.Local).AddTicks(111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 541, DateTimeKind.Local).AddTicks(7578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 752, DateTimeKind.Local).AddTicks(9283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 541, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AppUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 743, DateTimeKind.Local).AddTicks(1377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 530, DateTimeKind.Local).AddTicks(2879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AppUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 741, DateTimeKind.Local).AddTicks(9663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 528, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("647109ed-63aa-4dfc-a219-3a551d353af1"), "17d107e6-2495-442a-b4c1-af821fb7b162", "Người quản trị, có quyền quản lý hệ thống", "admin", "admin" },
                    { new Guid("44d86938-d29e-48cf-8db3-4144aa15385a"), "d9ed17cf-4f8f-4d7b-9ecf-0c36a1e54d20", "Thành viên có đã đăng nhập", "member", "member" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("647109ed-63aa-4dfc-a219-3a551d353af1"), new Guid("f9ce118d-0ac9-4a9f-a20f-38b784c6b9dd") },
                    { new Guid("44d86938-d29e-48cf-8db3-4144aa15385a"), new Guid("8c596113-aa13-4cd3-8965-e3be8dc0626b") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Dob", "Email", "EmailConfirmed", "FullName", "Gender", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateBy", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("8c596113-aa13-4cd3-8965-e3be8dc0626b"), 0, "Đà Nẵng", "ImageUploads/member.jpg", "2ab241ef-a264-4af7-8257-1f052652ba07", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "seo169403@gmail.com", true, "Tôi là Thành viên", 1, false, false, null, "seo169403@gmail.com", "member", "AQAAAAEAACcQAAAAEFxEzgEuITKDzwgE2MfJxnkhZJ9MfSb29ZlXZ92c3FX+ooUYkrvHjDsegmG6L/yM/g==", null, false, "", false, "", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "member" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Dob", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateBy", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("f9ce118d-0ac9-4a9f-a20f-38b784c6b9dd"), 0, "TP Hồ Chí Minh", "ImageUploads/admin.jpg", "044d9ef9-c000-4de0-a515-60852527fee6", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "seo169401@gmail.com", true, "Tôi là Người quản trị", false, false, null, "seo169401@gmail.com", "admin", "AQAAAAEAACcQAAAAEBjyWHUSwcmYmmAWpX7lHUIpLnd/2bEffGVoa8NjwS2kRiXa9n7T4qjk+ywn9CfWxA==", null, false, "", false, "", new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Name", "UpdateBy", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Điện thoại xịn", false, "Điện thoại", "", new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Máy tính bảng xịn", false, "Máy tính bảng", "", new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Laptop xịn", false, "Laptop", "", new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "SmartWatch xịn", false, "SmartWatch", "", new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "Color", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "dark", "Trả hàng", "Trả hàng" },
                    { 5, "warning", "Đã hủy", "Đã hủy" },
                    { 2, "primary", "Chờ lấy hàng", "Chờ lấy hàng" },
                    { 1, "info   ", "Chờ xác nhận", "Chờ xác nhận" },
                    { 4, "success", "Đã giao", "Đã giao" },
                    { 3, "secondary", "Đang giao", "Đang giao" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Thanh toán khi nhận hàng", "Thanh toán khi nhận hàng" },
                    { 2, "Thanh toán bằng thẻ tín dụng/ ghi nợ", "Thanh toán bằng thẻ tín dụng/ ghi nợ" },
                    { 3, "Thanh toán bằng thẻ ATM nội địa có Internet Banking", "Thanh toán bằng Internet Banking" },
                    { 4, "hanh toán bằng ví eM", "hanh toán bằng ví eM" },
                    { 5, "Thanh toán bằng ví Momo", "Thanh toán bằng ví Momo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44d86938-d29e-48cf-8db3-4144aa15385a"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("647109ed-63aa-4dfc-a219-3a551d353af1"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("44d86938-d29e-48cf-8db3-4144aa15385a"), new Guid("8c596113-aa13-4cd3-8965-e3be8dc0626b") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("647109ed-63aa-4dfc-a219-3a551d353af1"), new Guid("f9ce118d-0ac9-4a9f-a20f-38b784c6b9dd") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c596113-aa13-4cd3-8965-e3be8dc0626b"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f9ce118d-0ac9-4a9f-a20f-38b784c6b9dd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 555, DateTimeKind.Local).AddTicks(4674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 766, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 555, DateTimeKind.Local).AddTicks(3935),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 766, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 547, DateTimeKind.Local).AddTicks(2745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 758, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 547, DateTimeKind.Local).AddTicks(1885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 758, DateTimeKind.Local).AddTicks(4194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 544, DateTimeKind.Local).AddTicks(7064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 755, DateTimeKind.Local).AddTicks(8927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 544, DateTimeKind.Local).AddTicks(6235),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 755, DateTimeKind.Local).AddTicks(8169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 541, DateTimeKind.Local).AddTicks(7578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 753, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 541, DateTimeKind.Local).AddTicks(6718),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 752, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AppUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 530, DateTimeKind.Local).AddTicks(2879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 743, DateTimeKind.Local).AddTicks(1377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AppUsers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 11, 5, 21, 19, 19, 528, DateTimeKind.Local).AddTicks(7091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 11, 5, 21, 19, 55, 741, DateTimeKind.Local).AddTicks(9663));
        }
    }
}
