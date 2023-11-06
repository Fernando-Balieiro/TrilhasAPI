using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaminhadasAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f90c6be-3751-4994-85f0-e6bad4231586"), "Easy" },
                    { new Guid("2de6b18d-94df-417a-a82b-a0fa8b163f1b"), "Very Easy" },
                    { new Guid("3c837143-382a-4580-99be-ccd2a57fdc68"), "Hard" },
                    { new Guid("7b259c66-3cb0-43d1-89dc-26ef9ea88e14"), "Medium" },
                    { new Guid("861c7029-2e1c-45e0-acfa-a887f848f617"), "Very Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("10864cb6-8add-4e76-a58c-ca789429cb7f"), "MT", "Mato Grosso", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" },
                    { new Guid("2f252ac1-2f78-41f8-99c4-a7490eb458d1"), "MG", "Minas Gerais", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" },
                    { new Guid("9a3afb46-dcd9-4722-8cb8-a8b0ed679363"), "SP", "São Paulo", "https://upload.wikimedia.org/wikipedia/commons/1/11/Parque_do_ibirapuera_visto_do_c%C3%A9u.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("4faa439e-b267-4012-9abd-2ebb5379f17f"), "Uma trilha muito bonita de se fazer com boa companhia", new Guid("7b259c66-3cb0-43d1-89dc-26ef9ea88e14"), 13.0, "Trilha de Águas da Prata", new Guid("9a3afb46-dcd9-4722-8cb8-a8b0ed679363"), "https://prataexpedicoes.com.br/wp-content/uploads/2020/10/IMG_0064.jpg" },
                    { new Guid("7fade95a-7037-4f68-8d16-8bf254f6fffa"), "Uma trilha de dificuldade difícil que leva ao pico mais alto do Brasil, o Pico da Bandeira, em Minas Gerais. A trilha é longa e íngreme, e exige bom condicionamento físico.", new Guid("7b259c66-3cb0-43d1-89dc-26ef9ea88e14"), 20.0, "Trilha do Pico da Bandeira", new Guid("2f252ac1-2f78-41f8-99c4-a7490eb458d1"), "https://upload.wikimedia.org/wikipedia/commons/8/8a/Pico_da_Bandeira_vista_MG.jpg" },
                    { new Guid("b346d5c1-31a6-4d1c-a659-23a9537ab4ad"), "Trilha muito boa com bastante aventura", new Guid("0f90c6be-3751-4994-85f0-e6bad4231586"), 13.0, "Trilha do ouro", new Guid("9a3afb46-dcd9-4722-8cb8-a8b0ed679363"), "https://prataexpedicoes.com.br/wp-content/uploads/2020/10/IMG_0064.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2de6b18d-94df-417a-a82b-a0fa8b163f1b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3c837143-382a-4580-99be-ccd2a57fdc68"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("861c7029-2e1c-45e0-acfa-a887f848f617"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("10864cb6-8add-4e76-a58c-ca789429cb7f"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("4faa439e-b267-4012-9abd-2ebb5379f17f"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("7fade95a-7037-4f68-8d16-8bf254f6fffa"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b346d5c1-31a6-4d1c-a659-23a9537ab4ad"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0f90c6be-3751-4994-85f0-e6bad4231586"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7b259c66-3cb0-43d1-89dc-26ef9ea88e14"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2f252ac1-2f78-41f8-99c4-a7490eb458d1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9a3afb46-dcd9-4722-8cb8-a8b0ed679363"));

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
    }
}
