using GCE.Domain.Fornecedores;

namespace GCE.Data.Configs.Fornecedores
{
    internal class FornecedorConfiguration : BaseConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            ToTable("fornecedores");
            Property(x => x.Tipo).IsRequired();
        }
    }
}