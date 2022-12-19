using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifcations.Migrations
{
    public partial class EditInMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bae3dd8-f146-4985-a43e-9206346bc026");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67813098-8519-4fa1-b56c-9844e176761d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d3a90d8-98ea-48b6-af7e-811368fecb61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a8f4834-8c99-4d4c-bdb6-f3561dbf3c46", "66cef72d-05ea-4d34-99cb-7aefa4f43775", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b15a2b17-5bd8-4c79-bf08-82f8e6360c0a", "dad70342-23a7-4e43-85e6-394603bf9bfa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b1b7c95f-d181-4b7c-83fa-20a3719689e3", 0, "8c0f98e4-cc91-4994-89d8-82da9fc23ce5", "IdentityUser", "Admin123@gamil.com", true, true, null, null, null, "Admin123", null, false, "41a3ed38-656e-4afa-b3e0-d504b21a9953", false, "Admin123@gamil.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a8f4834-8c99-4d4c-bdb6-f3561dbf3c46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b15a2b17-5bd8-4c79-bf08-82f8e6360c0a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b7c95f-d181-4b7c-83fa-20a3719689e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bae3dd8-f146-4985-a43e-9206346bc026", "0f7e4e26-1915-4727-89bb-c781700df6a2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67813098-8519-4fa1-b56c-9844e176761d", "0d361e61-37b7-47f7-ba77-754ad72699ae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9d3a90d8-98ea-48b6-af7e-811368fecb61", 0, "109e8388-1733-4db0-ae44-1e572e3d6d52", "IdentityUser", "Admin123@gamil.com", true, true, null, null, null, "Admin123", null, false, "1f3ada1e-7290-41a8-b126-f35b77e3fa96", false, "Admin123@gamil.com" });
        }
    }
}
