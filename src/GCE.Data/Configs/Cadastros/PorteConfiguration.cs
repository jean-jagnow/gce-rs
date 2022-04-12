using GCE.Domain.Cadastros;

namespace GCE.Data.Configs.Cadastros
{
    internal class PorteConfiguration : BaseConfiguration<Porte>
    {
        public PorteConfiguration()
        {
            ToTable("portes");
            Property(x => x.Descricao).HasMaxLength(80).IsRequired()
                .HasColumnType("varchar");
        }
    }
}