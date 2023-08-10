using CalendarBooking.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CalendarBooking.Data
{
    public partial class CalendarBookingContext : DbContext
    {
        public CalendarBookingContext(DbContextOptions<CalendarBookingContext> options) : base(options) { }

        public virtual DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public class CalendarBookingContextFactory : IDesignTimeDbContextFactory<CalendarBookingContext>
        //{
        //    public CalendarBookingContext CreateDbContext(string[] args)
        //    {
        //        var optionBuilder = new DbContextOptionsBuilder<CalendarBookingContext>();
        //        optionBuilder.UseSqlServer("Data Source=LAPTOP-7C70UPGB;Initial Catalog=SwastiFashionHubLLPDB;User ID=sa;Password=saadmin;TrustServerCertificate=True");
        //        return new CalendarBookingContext(optionBuilder.Options);
        //    }
        //}
    }
}
