// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210309022917_UserMigration")]
    partial class UserMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c76a1dcc-12fd-40f3-a9ec-5c8b297fc0c4"),
                            CreateAt = new DateTime(2021, 3, 8, 23, 29, 17, 759, DateTimeKind.Local).AddTicks(6912),
                            Email = "emailAdmin@email.com",
                            Name = "Admnistrador",
                            UpdateAt = new DateTime(2021, 3, 8, 23, 29, 17, 760, DateTimeKind.Local).AddTicks(4332)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
