using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaminhadasAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDasRegioes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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


            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb2f443-820d-431c-919b-758d1d246596"), "Medium" },
                    { new Guid("5c0d3ec3-50eb-49b4-8520-ae4aa3883295"), "Easy" },
                    { new Guid("8139c96a-85b1-4fb8-8da5-a98d2964f47e"), "Hard" },
                    { new Guid("c8037095-c089-4a1b-8043-db118bbafbf3"), "Very Easy" },
                    { new Guid("dcf479af-5a33-42ee-9b2f-195488526233"), "Very Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1431186f-fae9-40ff-961c-66ed9858d4fd"), "MT", "Mato Grosso", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" },
                    { new Guid("264d1902-5432-47db-9430-d3fac3953b50"), "SP", "São Paulo", "https://upload.wikimedia.org/wikipedia/commons/1/11/Parque_do_ibirapuera_visto_do_c%C3%A9u.jpg" },
                    { new Guid("f0772e4b-1874-48e3-b810-bb3fe48851e6"), "MG", "Minas Gerais", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4fb2f443-820d-431c-919b-758d1d246596"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5c0d3ec3-50eb-49b4-8520-ae4aa3883295"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8139c96a-85b1-4fb8-8da5-a98d2964f47e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c8037095-c089-4a1b-8043-db118bbafbf3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dcf479af-5a33-42ee-9b2f-195488526233"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1431186f-fae9-40ff-961c-66ed9858d4fd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("264d1902-5432-47db-9430-d3fac3953b50"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f0772e4b-1874-48e3-b810-bb3fe48851e6"));

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Walks",
                newName: "Descrition");

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
    }
}
