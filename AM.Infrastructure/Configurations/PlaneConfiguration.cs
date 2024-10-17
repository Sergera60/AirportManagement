using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(p => p.PlaneId);

            // Set the table name to "MyPlanes"
            builder.ToTable("MyPlanes");

            // Set the column name for Capacity to "PlaneCapacity"
            builder.Property(p => p.Capacity)
                   .HasColumnName("PlaneCapacity");
        }
    }
}
