using ApiProcesso.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProcesso.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(50);
            builder.Property(x =>x.contato).IsRequired().HasMaxLength(50);
        }
    }
}
