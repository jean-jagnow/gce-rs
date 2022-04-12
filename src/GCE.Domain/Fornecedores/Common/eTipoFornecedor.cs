using System.ComponentModel;

namespace GCE.Domain.Fornecedores.Common
{
    public enum eTipoFornecedor : short
    {
        [Description("Pessoa Jurídica")]
        Pessoa_Juridica = 1,

        [Description("Pessoa Física")]
        Pessoa_Fisica = 2,
    }
}