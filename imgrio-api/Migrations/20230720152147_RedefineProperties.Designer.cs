﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using imgrio_api.Data;

#nullable disable

namespace imgrio_api.Migrations
{
    [DbContext(typeof(ImgrioDbContext))]
    [Migration("20230720152147_RedefineProperties")]
    partial class RedefineProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("imgrio_api.Models.UploadedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsSelfHosted")
                        .HasColumnType("boolean");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UploadedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UploadedFiles");
                });
#pragma warning restore 612, 618
        }
    }
}