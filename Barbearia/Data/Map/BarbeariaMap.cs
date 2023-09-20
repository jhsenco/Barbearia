using Barbearia.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Data.Map
{
    public class BarbeariaMap : IEntityTypeConfiguration<BarbeariaModel>
    {
        public void Configure(EntityTypeBuilder<BarbeariaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(128);
        }
    }
}

