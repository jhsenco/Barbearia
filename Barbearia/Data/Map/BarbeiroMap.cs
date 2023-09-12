using Barbearia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Barbearia.Data.Map
{
    public class BarbeiroMap : IEntityTypeConfiguration<BarbeiroModel>
    {
        public void Configure(EntityTypeBuilder<BarbeiroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Especialidade).IsRequired().HasMaxLength(128);
        }
    }
}
