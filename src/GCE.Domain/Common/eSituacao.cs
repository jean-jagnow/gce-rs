using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Application.Common
{
    public enum eSituacao : short
    {
        [Description("Em Elaboração")]
        Elaboracao,

        [Description("Ativo")]
        Ativo,

        [Description("Desativado")]
        Desativado,
    }
}
