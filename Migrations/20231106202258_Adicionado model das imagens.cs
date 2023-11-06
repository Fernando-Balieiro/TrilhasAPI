using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaminhadasAPI.Migrations
{
    /// <inheritdoc />
    public partial class Adicionadomodeldasimagens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileDescription = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5daa5b5f-b9ee-42ba-91eb-cdc550425530"), "Hard" },
                    { new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"), "Medium" },
                    { new Guid("c4767b2c-920d-414c-b6b9-feea1fe9f63e"), "Very Easy" },
                    { new Guid("cdf889a7-038d-4b72-b106-ff23434f0ba1"), "Easy" },
                    { new Guid("f1c08b38-9e1a-4693-8beb-0b9844e57fde"), "Very Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"), "SP", "São Paulo", "https://upload.wikimedia.org/wikipedia/commons/1/11/Parque_do_ibirapuera_visto_do_c%C3%A9u.jpg" },
                    { new Guid("6b813adf-eb5f-4946-90c0-29ee2d6e4f89"), "MT", "Mato Grosso", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" },
                    { new Guid("c4689f4e-df21-4c84-8749-6a0edad032d9"), "MG", "Minas Gerais", "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LengthInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("1998c6b1-7ec9-47a8-8114-7acf8b6f244b"), "Uma trilha muito bonita de se fazer com boa companhia", new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"), 13.0, "Trilha de Águas da Prata", new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"), "https://prataexpedicoes.com.br/wp-content/uploads/2020/10/IMG_0064.jpg" },
                    { new Guid("45a94229-d013-417f-a555-07759c229f35"), "Trilha muito boa com bastante aventura", new Guid("cdf889a7-038d-4b72-b106-ff23434f0ba1"), 13.0, "Trilha do ouro", new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"), "https://prataexpedicoes.com.br/wp-content/uploads/2020/10/IMG_0064.jpg" },
                    { new Guid("d19f30b1-af8b-483e-8c06-23b06919fec9"), "Uma trilha de dificuldade difícil que leva ao pico mais alto do Brasil, o Pico da Bandeira, em Minas Gerais. A trilha é longa e íngreme, e exige bom condicionamento físico.", new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"), 20.0, "Trilha do Pico da Bandeira", new Guid("c4689f4e-df21-4c84-8749-6a0edad032d9"), "https://upload.wikimedia.org/wikipedia/commons/8/8a/Pico_da_Bandeira_vista_MG.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5daa5b5f-b9ee-42ba-91eb-cdc550425530"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c4767b2c-920d-414c-b6b9-feea1fe9f63e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f1c08b38-9e1a-4693-8beb-0b9844e57fde"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6b813adf-eb5f-4946-90c0-29ee2d6e4f89"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("1998c6b1-7ec9-47a8-8114-7acf8b6f244b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("45a94229-d013-417f-a555-07759c229f35"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("d19f30b1-af8b-483e-8c06-23b06919fec9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cdf889a7-038d-4b72-b106-ff23434f0ba1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c4689f4e-df21-4c84-8749-6a0edad032d9"));

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
    }
}
