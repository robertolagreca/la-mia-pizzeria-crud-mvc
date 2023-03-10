// <auto-generated />
using System;
using LaMiaPizzeriaCategoriaETag.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaMiaPizzeriaCategoriaETag.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20230119134532_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LaMiaPizzeriaCategoriaETag.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LaMiaPizzeriaCategoriaETag.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(30)");

                    b.Property<float>("Price")
                        .HasColumnType("float(2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("LaMiaPizzeriaCategoriaETag.Models.Pizza", b =>
                {
                    b.HasOne("LaMiaPizzeriaCategoriaETag.Models.Category", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LaMiaPizzeriaCategoriaETag.Models.Category", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
