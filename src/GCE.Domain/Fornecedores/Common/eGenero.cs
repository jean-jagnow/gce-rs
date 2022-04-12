using System.ComponentModel;

namespace GCE.Domain.Fornecedores.Common
{
    public enum eGenero : short
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino
    }
}