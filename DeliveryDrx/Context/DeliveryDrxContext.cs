using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Entities.SpecialEntities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDrxAPI.Context
{
    public class DeliveryDrxContext:DbContext
    {
        public DeliveryDrxContext(DbContextOptions<DeliveryDrxContext> options):base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<TransportSchedule> TransportSchedules { get; set; }
        public DbSet<LocationManager> LocationManagers { get; set; }
        //public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DriversMock
            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = 1,
                    FirstName = "first name test",
                    LastName = "last name test",
                    Email = "email test",
                    PhoneNumber = "phone test"
                }
             );
            #endregion
            #region GatesMock
            modelBuilder.Entity<Gate>().HasData(
                new Gate
                {
                    Id = 1,
                    LocationId = 1
                },
                new Gate
                {
                    Id = 2,
                    LocationId = 1
                },
                new Gate
                {
                    Id = 3,
                    LocationId = 1
                },
                new Gate
                {
                    Id = 4,
                    LocationId = 2
                },
                new Gate
                {
                    Id = 5,
                    LocationId = 3
                }
                );
            #endregion
            #region LocationsMock
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Address = "Address 1"
                },
                new Location
                {
                    Id = 2,
                    Address = "Address 2"
                },
                new Location
                {
                    Id = 3,
                    Address = "Address 3"
                }
                );
            #endregion
            #region LocationManagersMock

            #endregion
            #region TransportsMock
            #endregion
            #region TransportSchedulesMock
            modelBuilder.Entity<TransportSchedule>()
                .HasOne(ts => ts.Transport)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region UsersMock

            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
