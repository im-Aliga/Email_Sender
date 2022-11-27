﻿// <auto-generated />
using EmailSender.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmailSender.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221126163646_RelationShipEmailAndNotification")]
    partial class RelationShipEmailAndNotification
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmailSender.Database.Models.EmailModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DBEmail");
                });

            modelBuilder.Entity("EmailSender.Database.Models.NotificationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<int>("EmailModelId")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailModelId");

                    b.ToTable("DBNotification");
                });

            modelBuilder.Entity("EmailSender.Database.Models.NotificationModel", b =>
                {
                    b.HasOne("EmailSender.Database.Models.EmailModel", "EmailModel")
                        .WithMany("Notification")
                        .HasForeignKey("EmailModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmailModel");
                });

            modelBuilder.Entity("EmailSender.Database.Models.EmailModel", b =>
                {
                    b.Navigation("Notification");
                });
#pragma warning restore 612, 618
        }
    }
}
