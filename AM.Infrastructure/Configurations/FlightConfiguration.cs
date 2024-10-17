using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // Configure many-to-many relationship between Flight and Passenger
            builder.HasMany(f => f.passengers)
                   .WithMany(p => p.flights);

            // Configure one-to-many relationship between Flight and Plane
            builder.HasOne(f => f.Plane)
                  .WithMany(p => p.flight)
                 .HasForeignKey(f => f.PlaneId);
        }
    }
}
