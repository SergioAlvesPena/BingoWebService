using BingoWS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingoWS.Data
{
    public class DataMapping : IEntityTypeConfiguration<Cartela>
    {
        public void Configure(EntityTypeBuilder<Cartela> builder)
        {
            builder.HasNoKey();
        }
    }
}
