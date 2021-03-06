// <auto-generated />
using System;
using BonusPointManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BonusPointManager.Migrations
{
    [DbContext(typeof(BonusPointManagerContext))]
    [Migration("20220521112249_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusPointType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("EurobonusPointType");
                });

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusTransaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("AcquiredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointTypeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PointTypeId");

                    b.ToTable("EurobonusTransaction");
                });

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusTransaction", b =>
                {
                    b.HasOne("BonusPointManager.Models.Eurobonus.EurobonusPointType", "PointType")
                        .WithMany()
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PointType");
                });
#pragma warning restore 612, 618
        }
    }
}
