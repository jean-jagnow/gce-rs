using GCE.Application.Common;
using GCE.Domain.Cadastros;
using GCE.Domain.Fornecedores.Common;

namespace GCE.Domain.Fornecedores
{
    public class Fornecedor : Entity
    {
        public Fornecedor(TipoEmpresa tipoEmpresa, bool nacional)
        {
            TipoEmpresa = tipoEmpresa;
            Nacional = nacional;
        }

        private Fornecedor()
        {
        }

        public eTipoFornecedor Tipo { get; private set; }
        public TipoEmpresa TipoEmpresa { get; set; }
        public bool Nacional { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }

        public Fornecedor NovoPessoaFisica(PessoaFisica pessoaFisica)
        {
            Tipo = eTipoFornecedor.Pessoa_Fisica;
            PessoaFisica = pessoaFisica;

            return this;
        }
        public Fornecedor NovoPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            Tipo = eTipoFornecedor.Pessoa_Juridica;
            PessoaJuridica = pessoaJuridica;

            return this;
        }
    }
}