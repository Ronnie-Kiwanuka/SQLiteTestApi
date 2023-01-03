using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace SQLiteTestApi.Models
{
    public class CountryContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public string DbPath { get; }

        public CountryContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "countries.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
