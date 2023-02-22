﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskApi.Models;

#nullable disable

namespace TaskApi.Migrations
{
    [DbContext(typeof(MapDbContext))]
    partial class MapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskApi.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClusterRaduis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsGeoFencing")
                        .HasColumnType("bit");

                    b.Property<double>("LocationBuffer")
                        .HasColumnType("float");

                    b.Property<int>("MapSubTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MapTypeId")
                        .HasColumnType("int");

                    b.Property<double>("TimeBuffer")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MapSubTypeId");

                    b.HasIndex("MapTypeId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("TaskApi.Models.MapSubType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MapTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MapTypeId");

                    b.ToTable("MapSubTypes");
                });

            modelBuilder.Entity("TaskApi.Models.MapType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MapTypes");
                });

            modelBuilder.Entity("TaskApi.Models.Map", b =>
                {
                    b.HasOne("TaskApi.Models.MapSubType", "MapSubType")
                        .WithMany()
                        .HasForeignKey("MapSubTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskApi.Models.MapType", "MapType")
                        .WithMany()
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MapSubType");

                    b.Navigation("MapType");
                });

            modelBuilder.Entity("TaskApi.Models.MapSubType", b =>
                {
                    b.HasOne("TaskApi.Models.MapType", "MapType")
                        .WithMany()
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MapType");
                });
#pragma warning restore 612, 618
        }
    }
}
