using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Domain.Core.Events;

namespace Infrastruct.Data.Mappings
{
    public class StoredEventMap : IEntityTypeConfiguration<StoreEvent>
    {
        

        public void Configure(EntityTypeBuilder<StoreEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
               .HasColumnName("Action")
               .HasColumnType("varchar(100)");
        }
    }
}
