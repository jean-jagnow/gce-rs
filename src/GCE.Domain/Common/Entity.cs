using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Application.Common
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; private set; } = DateTime.Now;
        public DateTime DataDaUltimaAlteracao { get; set; } = DateTime.Now;
        public eSituacao Situacao { get; set; } = eSituacao.Elaboracao;
    }
}
