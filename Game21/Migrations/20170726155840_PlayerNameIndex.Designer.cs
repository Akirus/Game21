using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Game21.Data;

namespace Game21.Migrations
{
    [DbContext(typeof(PlayersContext))]
    [Migration("20170726155840_PlayerNameIndex")]
    partial class PlayerNameIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Game21.Data.Models.Player", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Game21.Data.Models.Stats", b =>
                {
                    b.Property<string>("PlayerId");

                    b.Property<int>("DefeatsCount");

                    b.Property<DateTimeOffset>("LastVisit");

                    b.Property<int>("TotalVisits");

                    b.Property<int>("WinsCount");

                    b.HasKey("PlayerId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Game21.Data.Models.Stats", b =>
                {
                    b.HasOne("Game21.Data.Models.Player", "Player")
                        .WithOne("PlayerStats")
                        .HasForeignKey("Game21.Data.Models.Stats", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
