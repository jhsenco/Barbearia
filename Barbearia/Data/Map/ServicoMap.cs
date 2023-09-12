using Barbearia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barbearia.Data.Map
{
    public class ServicoMap : IEntityTypeConfiguration<ServicoModel>
    {
        public void Configure(EntityTypeBuilder<ServicoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(128);
            builder.Property(x => x.BarbeiroId);

            builder.HasOne(x => x.Barbeiro);
        }
    }
}
