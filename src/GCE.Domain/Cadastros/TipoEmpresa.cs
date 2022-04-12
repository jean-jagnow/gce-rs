using GCE.Domain.Common;
using System.Collections.Generic;

namespace GCE.Domain.Cadastros
{
    public class TipoEmpresa : Entity
    {
        private TipoEmpresa()
        {
        }
        public TipoEmpresa(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        public virtual ICollection<Fornecedores.Fornecedor> Fornecedores { get; private set; }
    }
}