using GCE.Domain.Fornecedores.Common;
using System;

namespace GCE.Domain.Fornecedores
{
    public class PessoaFisica : Detalhe
    {
        public PessoaFisica(string cpf, string nome, string profissao,
            eGenero genero, Contato contato, DateTime dataNascimento)
        {
            Cpf = cpf;
            Nome = nome;
            Profissao = profissao;
            Genero = genero;
            Contato = contato;
            DataNascimento = dataNascimento;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public eGenero Genero { get; set; }
        public Contato Contato { get; set; }

        public eEstadoCivil? EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
    }
}