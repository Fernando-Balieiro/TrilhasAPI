using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaminhadasAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1fe38b76-cc9c-47ce-9b18-bb08b77335bf"), "Very Easy" },
                    { new Guid("249ab280-e815-44ed-8593-b87f30b3fcca"), "Medium" },
                    { new Guid("2facf73b-413a-4f41-8fb1-9c0db21e15cd"), "Hard" },
                    { new Guid("7fbd596b-1522-4c31-aac2-e1759654903f"), "Easy" },
                    { new Guid("8c880814-0a32-47f6-a372-f298b830b405"), "Very Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3022ea41-1cac-4ba5-9630-405e89742e5a"), "SP", "São Paulo", "https://upload.wikimedia.org/wikipedia/commons/1/11/Parque_do_ibirapuera_visto_do_c%C3%A9u.jpg" },
                    { new Guid("56a3a88e-b943-4fb0-9959-c74c183101c8"), "MG", "Mato Grosso", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" },
                    { new Guid("a0e7c59e-408f-4a00-a947-7210b6c0e963"), "MG", "Minas Gerais", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1fe38b76-cc9c-47ce-9b18-bb08b77335bf"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("249ab280-e815-44ed-8593-b87f30b3fcca"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2facf73b-413a-4f41-8fb1-9c0db21e15cd"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7fbd596b-1522-4c31-aac2-e1759654903f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8c880814-0a32-47f6-a372-f298b830b405"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3022ea41-1cac-4ba5-9630-405e89742e5a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("56a3a88e-b943-4fb0-9959-c74c183101c8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a0e7c59e-408f-4a00-a947-7210b6c0e963"));
        }
    }
}
