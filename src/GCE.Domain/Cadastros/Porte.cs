using GCE.Domain.Common;
using System.Collections.Generic;

namespace GCE.Domain.Cadastros
{
    public class Porte : Entity
    {
        private Porte()
        {
        }
        public Porte(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        public virtual ICollection<Fornecedores.PessoaJuridica> Fornecedores { get; private set; }
    }
}