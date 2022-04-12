using GCE.Domain.Cadastros;

namespace GCE.Data.Configs.Cadastros
{
    internal class TipoEmpresaConfiguration : BaseConfiguration<TipoEmpresa>
    {
        public TipoEmpresaConfiguration()
        {
            ToTable("tipos_de_empresas");
            Property(x => x.Descricao).HasMaxLength(80).IsRequired()
                .HasColumnType("varchar");
        }
    }
}