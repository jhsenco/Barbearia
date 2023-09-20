using Barbearia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barbearia.Data.Map
{
    public class AgendamentoMap : IEntityTypeConfiguration<AgendamentoModel>
    {
        public void Configure(EntityTypeBuilder<AgendamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BarbeariaId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.ClienteId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.BarbeiroId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.ServicoId).IsRequired().HasMaxLength(128);
            builder.Property(x => x.DataHora).IsRequired().HasMaxLength(128);
    
        }
    }
}
