using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifcations.Migrations
{
    public partial class NormalizedNameOfRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33b50422-b1c3-434e-885e-e7782c9be379");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d85d1a24-0391-4d92-abec-fea78ab58df7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cef220bf-ca54-40f0-9454-1dcf2304121a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "992d8aac-6c5d-4135-ac73-82710d39a1cf", "8abfcb11-837b-40dc-bd21-a958b74f8b64", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b231d7e8-662f-471e-9980-292e388b2ed1", "711774c8-2183-4ade-968f-403b7b5434fc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "001060d3-be7e-4fb2-9c52-17e4319dc80b", 0, "4e65bd8c-6d16-4531-8e98-56cd136d6b4f", "IdentityUser", "Admin123@gamil.com", true, true, null, null, null, "Admin123", null, false, "0c742694-d579-4a60-8fc1-f558be431d9a", false, "Admin123@gamil.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "992d8aac-6c5d-4135-ac73-82710d39a1cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b231d7e8-662f-471e-9980-292e388b2ed1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "001060d3-be7e-4fb2-9c52-17e4319dc80b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33b50422-b1c3-434e-885e-e7782c9be379", "5a34a976-6b2e-4ca3-9a2c-a48ab1ffb834", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d85d1a24-0391-4d92-abec-fea78ab58df7", "ee45ed41-a35c-4bda-8054-f1b97edeab39", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cef220bf-ca54-40f0-9454-1dcf2304121a", 0, "095ccd72-aca2-4b7f-9f8f-8dd2d214d502", "IdentityUser", "Admin123@gamil.com", true, true, null, null, null, "Admin123", null, false, "8be906df-1b7e-469c-b098-b7ecf530b1bc", false, "Admin123@gamil.com" });
        }
    }
}
