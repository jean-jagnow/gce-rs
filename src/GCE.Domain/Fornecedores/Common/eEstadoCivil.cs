using System.ComponentModel;

namespace GCE.Domain.Fornecedores.Common
{
    public enum eEstadoCivil : short
    {
        [Description("Solteiro")]
        Solteiro = 1,

        [Description("Casado")]
        Casado,

        [Description("Separado")]
        Separado,

        [Description("Divorciado")]
        Divorciado,

        [Description("Viúvo")]
        Viuvo
    }
}