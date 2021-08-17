using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Model.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    idIdentificationType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identificationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    identificationDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.idIdentificationType);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    idCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identificationNumber = table.Column<int>(type: "int", nullable: false),
                    nitCompany = table.Column<int>(type: "int", nullable: false),
                    companyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    firtsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    secondName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    firtsLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    secondLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    authorizedSendEmail = table.Column<bool>(type: "bit", nullable: false),
                    authorizedSendPhone = table.Column<bool>(type: "bit", nullable: false),
                    unableRegistry = table.Column<bool>(type: "bit", nullable: false),
                    idIdentificationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.idCompany);
                    table.ForeignKey(
                        name: "FK_identificationTypeToCompany",
                        column: x => x.idIdentificationType,
                        principalTable: "IdentificationType",
                        principalColumn: "idIdentificationType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyRegistry",
                columns: table => new
                {
                    idCompanyRegistry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateRegistry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRegistry", x => x.idCompanyRegistry);
                    table.ForeignKey(
                        name: "FK_CompanyToCompanyRegistry",
                        column: x => x.idCompany,
                        principalTable: "Company",
                        principalColumn: "idCompany",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IdentificationType",
                columns: new[] { "idIdentificationType", "identificationDescription", "identificationName" },
                values: new object[,]
                {
                    { 1, "Descripción de NIT", "NIT" },
                    { 2, "Descripción de Cedula de Ciudadania", "Cedula Ciudadania" },
                    { 3, "Descripción de Cedula de Extranjeria", "Cedula Extranjeria" },
                    { 4, "Descripción de Pasaporte", "Pasaporte" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "idCompany", "authorizedSendEmail", "authorizedSendPhone", "companyName", "email", "firtsLastName", "firtsName", "idIdentificationType", "identificationNumber", "nitCompany", "phone", "secondLastName", "secondName", "unableRegistry" },
                values: new object[] { 1, false, false, "Nombre Compañia 1", "emailcompania1@email.com", null, null, 1, 900674335, 900674335, "333444555", null, null, true });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "idCompany", "authorizedSendEmail", "authorizedSendPhone", "companyName", "email", "firtsLastName", "firtsName", "idIdentificationType", "identificationNumber", "nitCompany", "phone", "secondLastName", "secondName", "unableRegistry" },
                values: new object[] { 2, false, false, null, "pedroperez@email.com", "Perez", "Pedro", 2, 1222333444, 900674336, "344566788", null, null, false });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "idCompany", "authorizedSendEmail", "authorizedSendPhone", "companyName", "email", "firtsLastName", "firtsName", "idIdentificationType", "identificationNumber", "nitCompany", "phone", "secondLastName", "secondName", "unableRegistry" },
                values: new object[] { 3, false, false, "Nombre Compañia 2", "emailcompania2@email.com", null, null, 3, 8907654, 811033098, "322433544", null, null, false });

            migrationBuilder.CreateIndex(
                name: "IX_Company_idIdentificationType",
                table: "Company",
                column: "idIdentificationType");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRegistry_idCompany",
                table: "CompanyRegistry",
                column: "idCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyRegistry");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "IdentificationType");
        }
    }
}
