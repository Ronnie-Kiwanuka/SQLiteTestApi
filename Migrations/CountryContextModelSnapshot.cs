// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQLiteTestApi.Models;

#nullable disable

namespace SQLiteTestApi.Migrations
{
    [DbContext(typeof(CountryContext))]
    partial class CountryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("SQLiteTestApi.Models.Country", b =>
                {
                    b.Property<int>("countryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("countryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("countryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("countryId");

                    b.ToTable("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
