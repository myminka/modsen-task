﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModsenTask.Services.EntityFrameworkCore.Events.Context;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Migrations
{
    [DbContext(typeof(EventDataContext))]
    [Migration("20220715051605_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModsenTask.Services.EntityFrameworkCore.Events.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnName("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventDataId")
                        .HasColumnName("event_data_id")
                        .HasColumnType("int");

                    b.Property<int>("HouseNumber")
                        .HasColumnName("house_number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventDataId")
                        .IsUnique();

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("ModsenTask.Services.EntityFrameworkCore.Events.Entities.EventData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("discription")
                        .HasColumnType("ntext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Organiser")
                        .HasColumnName("organiser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("eventDatas");
                });

            modelBuilder.Entity("ModsenTask.Services.EntityFrameworkCore.Events.Entities.Address", b =>
                {
                    b.HasOne("ModsenTask.Services.EntityFrameworkCore.Events.Entities.EventData", "EventData")
                        .WithOne("Address")
                        .HasForeignKey("ModsenTask.Services.EntityFrameworkCore.Events.Entities.Address", "EventDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
