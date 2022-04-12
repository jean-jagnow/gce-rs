using GCE.Application.Common;
using GCE.Domain.Cadastros;
using GCE.Domain.Fornecedores.Common;

namespace GCE.Domain.Fornecedores
{
    public class Fornecedor : Entity
    {
        private Fornecedor()
        {
        }

        public eTipoFornecedor Tipo { get; private set; }
        public bool Nacional { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }

        public Fornecedor NovoPessoaFisica(TipoEmpresa tipoEmpresa, PessoaFisica pessoaFisica)
        {
            Tipo = eTipoFornecedor.Pessoa_Fisica;
            TipoEmpresa = tipoEmpresa;
            PessoaFisica = pessoaFisica;

            return this;
        }
        public Fornecedor NovoPessoaJuridica(TipoEmpresa tipoEmpresa,PessoaJuridica pessoaJuridica)
        {
            Tipo = eTipoFornecedor.Pessoa_Juridica;
            TipoEmpresa = tipoEmpresa;
            PessoaJuridica = pessoaJuridica;

            return this;
        }
    }
}