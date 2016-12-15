using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PeopleSearch.Entities;

namespace PeopleSearch.Migrations
{
    [DbContext(typeof(PeopleSearchDbContext))]
    [Migration("20161215165605_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeopleSearch.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Interests");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("People");
                });
        }
    }
}
