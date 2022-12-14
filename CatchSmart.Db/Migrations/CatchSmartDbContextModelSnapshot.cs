// <auto-generated />
using CatchSmart.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CatchSmart.Migrations
{
    [DbContext(typeof(CatchSmartDbContext))]
    partial class CatchSmartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CatchSmart.Core.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("SkillSets")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("CatchSmart.Core.Models.CandidatePositions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CandidateId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CandidatePositions");
                });

            modelBuilder.Entity("CatchSmart.Core.Models.CompaniesPositions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CompanyPositions");
                });

            modelBuilder.Entity("CatchSmart.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<int>("OpenPositions")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CatchSmart.Core.Models.Positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
