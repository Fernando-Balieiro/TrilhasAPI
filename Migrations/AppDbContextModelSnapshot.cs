﻿// <auto-generated />
using System;
using CaminhadasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CaminhadasAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CaminhadasAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4767b2c-920d-414c-b6b9-feea1fe9f63e"),
                            Name = "Very Easy"
                        },
                        new
                        {
                            Id = new Guid("cdf889a7-038d-4b72-b106-ff23434f0ba1"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("5daa5b5f-b9ee-42ba-91eb-cdc550425530"),
                            Name = "Hard"
                        },
                        new
                        {
                            Id = new Guid("f1c08b38-9e1a-4693-8beb-0b9844e57fde"),
                            Name = "Very Hard"
                        });
                });

            modelBuilder.Entity("CaminhadasAPI.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileDescription")
                        .HasColumnType("text");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CaminhadasAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegionImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"),
                            Code = "SP",
                            Name = "São Paulo",
                            RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/11/Parque_do_ibirapuera_visto_do_c%C3%A9u.jpg"
                        },
                        new
                        {
                            Id = new Guid("c4689f4e-df21-4c84-8749-6a0edad032d9"),
                            Code = "MG",
                            Name = "Minas Gerais",
                            RegionImageUrl = "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg"
                        },
                        new
                        {
                            Id = new Guid("6b813adf-eb5f-4946-90c0-29ee2d6e4f89"),
                            Code = "MT",
                            Name = "Mato Grosso",
                            RegionImageUrl = "https://blog.entretrilhas.com.br/wp-content/uploads/2022/02/trekking_02-1024x576.jpg"
                        });
                });

            modelBuilder.Entity("CaminhadasAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uuid");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uuid");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1998c6b1-7ec9-47a8-8114-7acf8b6f244b"),
                            Description = "Uma trilha muito bonita de se fazer com boa companhia",
                            DifficultyId = new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"),
                            LengthInKm = 13.0,
                            Name = "Trilha de Águas da Prata",
                            RegionId = new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"),
                            WalkImageUrl = "https://prataexpedicoes.com.br/wp-content/uploads/2020/10/IMG_0064.jpg"
                        },
                        new
                        {
                            Id = new Guid("45a94229-d013-417f-a555-07759c229f35"),
                            Description = "Trilha muito boa com bastante aventura",
                            DifficultyId = new Guid("cdf889a7-038d-4b72-b106-ff23434f0ba1"),
                            LengthInKm = 13.0,
                            Name = "Trilha do ouro",
                            RegionId = new Guid("414a8bb1-e8af-49ef-af8e-94eaef02540d"),
                            WalkImageUrl = "https://prataexpedicoes.com.br/wp-content/uploads/2020/10/IMG_0064.jpg"
                        },
                        new
                        {
                            Id = new Guid("d19f30b1-af8b-483e-8c06-23b06919fec9"),
                            Description = "Uma trilha de dificuldade difícil que leva ao pico mais alto do Brasil, o Pico da Bandeira, em Minas Gerais. A trilha é longa e íngreme, e exige bom condicionamento físico.",
                            DifficultyId = new Guid("9a606e68-1bcc-4b09-9159-bdcdc2257c8a"),
                            LengthInKm = 20.0,
                            Name = "Trilha do Pico da Bandeira",
                            RegionId = new Guid("c4689f4e-df21-4c84-8749-6a0edad032d9"),
                            WalkImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8a/Pico_da_Bandeira_vista_MG.jpg"
                        });
                });

            modelBuilder.Entity("CaminhadasAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("CaminhadasAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaminhadasAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
