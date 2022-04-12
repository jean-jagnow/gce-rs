using GCE.Domain.Cadastros;

namespace GCE.Data.Configs.Cadastros
{
    internal class CaracterizacaoCapitalConfiguration : BaseConfiguration<CaracterizacaoCapital>
    {
        public CaracterizacaoCapitalConfiguration()
        {
            ToTable("caracterizacoes_capital");
            Property(x => x.Descricao).HasMaxLength(80).IsRequired()
                .HasColumnType("varchar");
        }
    }
}