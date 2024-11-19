using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {


        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set;}
        public DbSet<Traveller> Travellers { get; set;}
        public DbSet<Staff> Staff { get; set;}
        public DbSet<Ticket> Tickets { get; set;}
      


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
                                        Initial Catalog=AirportManagementDB;
                                        Integrated Security=true ;
                                        MultipleActiveResultSets=True")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //fluentAPI 
        {
            // Apply the PlaneConfiguration
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
/* 2nd method
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(p => p.Capacity)
                .HasColumnName("PlaneCapacity");*/

            // Apply the FlightConfiguration
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);

          /*  modelBuilder.Entity<Passenger>()
                .HasDiscriminator<int>("IsTravaller")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2);*/

            modelBuilder.Entity<Traveller>()
                .ToTable("Travellers");

            modelBuilder.Entity<Staff>()
                .ToTable("Staffs");

            modelBuilder.Entity<Ticket>()
              .HasKey(t => new
              {
                  t.FlightFK,
                  t.PassengerFK
              });
            /*
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightFK);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PassengerFK);*/

            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Configure all DateTime properties to use the "date" type in the database
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");

            base.ConfigureConventions(configurationBuilder);
        }
    }
}
