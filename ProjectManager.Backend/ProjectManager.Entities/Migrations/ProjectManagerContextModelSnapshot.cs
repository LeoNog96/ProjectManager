﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectManager.Entities.Context;

namespace ProjectManager.Entities.Migrations
{
    [DbContext(typeof(ProjectManagerContext))]
    partial class ProjectManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProjectManager.Entities.Models.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("FinalDate")
                        .HasColumnName("final_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("Finished")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("finished")
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("false");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnName("initial_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<long>("ProjectId")
                        .HasColumnName("project_id")
                        .HasColumnType("bigint");

                    b.Property<bool?>("Running")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("running")
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("false");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("activity");
                });

            modelBuilder.Entity("ProjectManager.Entities.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("FinalDate")
                        .HasColumnName("final_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnName("initial_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Late")
                        .HasColumnName("late")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(250)")
                        .HasMaxLength(250);

                    b.Property<double>("PercentComplete")
                        .HasColumnName("percent_complete")
                        .HasColumnType("double precision");

                    b.Property<bool?>("Removed")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("removed")
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("false");

                    b.HasKey("Id");

                    b.ToTable("project");
                });

            modelBuilder.Entity("ProjectManager.Entities.Models.Activity", b =>
                {
                    b.HasOne("ProjectManager.Entities.Models.Project", "Project")
                        .WithMany("Activities")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("project_activity_id")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
