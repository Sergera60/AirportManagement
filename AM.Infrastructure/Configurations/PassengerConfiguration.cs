using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            // Configure the FullName complex type
            builder.OwnsOne(p => p.FullName, fn =>
            {
                // Configure FirstName with max length of 30 and column name "PassFirstName"
                fn.Property(f => f.FirstName)
                  .HasMaxLength(30)
                  .HasColumnName("PassFirstName");

                // Configure LastName as required and column name "PassLastName"
                fn.Property(f => f.LastName)
                  .IsRequired()
                  .HasColumnName("PassLastName");
            });

            // Other configurations (if any) can be added here
        }
    }
}
