using GCE.Domain.Fornecedores.Common;

namespace GCE.Domain.Fornecedores
{
    public class ContatoPessoaJuridica : Contato
    {
        private ContatoPessoaJuridica()
        {
        }
        public ContatoPessoaJuridica(string fone1, string emailPrincipal):base(fone1, emailPrincipal)
        { }
        public string Website { get; set; }
    }
}