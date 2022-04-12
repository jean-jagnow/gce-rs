using GCE.Application.Common;
using GCE.Domain.Fornecedores;
using System.Collections.Generic;
using System.Linq;

namespace GCE.Application.Services
{
    public class FornecedorService : CrudService<Fornecedor>
    {
        protected override void PodeSerAtualizado(Fornecedor entity)
        {
            if (db.Any(x => x.Id != entity.Id && 
                (entity.Tipo == Domain.Fornecedores.Common.eTipoFornecedor.Pessoa_Fisica 
                ? x.PessoaFisica.Cpf == entity.PessoaFisica.Cpf 
                : x.PessoaJuridica.Cnpj == entity.PessoaJuridica.Cnpj)
                && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe um fornecedor {entity.ObterNome()} ativa registrada.");
        }

        protected override void PodeSerCadastrado(Fornecedor entity)
        {
            if (db.Any(x =>
            (entity.Tipo == Domain.Fornecedores.Common.eTipoFornecedor.Pessoa_Fisica
                ? x.PessoaFisica.Cpf == entity.PessoaFisica.Cpf
                : x.PessoaJuridica.Cnpj == entity.PessoaJuridica.Cnpj) 
                && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe uma caracterização {entity.ObterNome()} ativa registrada.");

        }
    }
}
