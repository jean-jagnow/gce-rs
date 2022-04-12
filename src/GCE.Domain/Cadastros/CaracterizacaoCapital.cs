using GCE.Application.Common;
using System.Collections.Generic;

namespace GCE.Domain.Cadastros
{
    public class CaracterizacaoCapital : Entity
    {
        private CaracterizacaoCapital()
        {
        }
        public CaracterizacaoCapital(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; set; }

        public virtual ICollection<Fornecedores.PessoaJuridica> Fornecedores { get; private set; }
    }
}