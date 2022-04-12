using GCE.Domain.Cadastros;
using GCE.Domain.Fornecedores.Common;
using System;

namespace GCE.Domain.Fornecedores
{
    public class PessoaJuridica : Detalhe
    {
        private PessoaJuridica()
        {
        }
        public PessoaJuridica(string cnpj, string razaoSocial, Porte porteEmpresa,
            ContatoPessoaJuridica contato, decimal capitalSocial)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            PorteEmpresa = porteEmpresa;
            Contato = contato;
            CapitalSocial = capitalSocial;
        }

        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public Porte PorteEmpresa { get; set; }
        public ContatoPessoaJuridica Contato { get; set; }

        public string NomeFantasia { get; set; }
        public DateTime? DataContituicao { get; set; }
        public CaracterizacaoCapital Caracterizacao { get; set; }

        public decimal? QuantidadeQuota { get; set; }
        public decimal? ValorQuota { get; set; }
        public decimal CapitalSocial { get; set; }
    }
}