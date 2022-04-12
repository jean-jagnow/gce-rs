using GCE.Application.Services;
using GCE.Domain.Fornecedores;
using GCE.Domain.Fornecedores.Common;
using GCEApi.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCEApi.Services
{
    public class FornecedorManager : IDisposable
    {
        readonly FornecedorService fornecedorService;
        readonly TipoEmpresaService tipoEmpresaService;
        readonly PorteService porteService;
        readonly CaracterizacaoCapitalService caracterizacaoCapitalService;
        public FornecedorManager(FornecedorService fornecedorService)
        {
            this.fornecedorService = fornecedorService;
            tipoEmpresaService = new TipoEmpresaService();
            porteService = new PorteService();
            caracterizacaoCapitalService = new CaracterizacaoCapitalService();
        }

        public long CriarNovoPessoaFisica(FornecedorPessoaFisicaInputModel model)
        {
            var fornecedor = new Fornecedor(
                tipoEmpresaService.BuscarPorId(model.TipoEmpresa), model.Nacional)
                .NovoPessoaFisica(new PessoaFisica(model.Cpf, model.Nome, model.Profissao,
                (eGenero)Enum.Parse(typeof(eGenero), model.Genero), 
                new Contato(model.Fone1, model.EmailPrincipal)
                {
                    Fone2 = model.Fone2,
                    Fone3 = model.Fone3
                }, model.DataNascimento)
                {
                    EstadoCivil = (eEstadoCivil)Enum.Parse(typeof(eEstadoCivil), model.EstadoCivil)
                });

            fornecedorService.Cadastrar(fornecedor);

            return fornecedor.Id;
        }
        
        public long CriarNovoPessoaJuridica(FornecedorPessoaJuridicanputModel model)
        {
            var fornecedor = new Fornecedor(
                tipoEmpresaService.BuscarPorId(model.TipoEmpresa), model.Nacional)
                .NovoPessoaJuridica(new PessoaJuridica(model.Cnpj, model.RazaoSocial, model.NomeFantasia,
                porteService.BuscarPorId(model.PorteEmpresa),
                new ContatoPessoaJuridica(model.Fone1, model.EmailPrincipal)
                {
                    Website = model.Website,
                    Fone2 = model.Fone2,
                    Fone3 = model.Fone3
                }, model.CapitalSocial)
                {
                    Caracterizacao = caracterizacaoCapitalService.BuscarPorId(model.Caracterizacao),
                    ValorQuota = model.ValorQuota,
                    QuantidadeQuota = model.QuantidadeQuota
                });

            fornecedorService.Cadastrar(fornecedor);

            return fornecedor.Id;
        }
        public void AtualizarPessoaJuridica(FornecedorPessoaJuridicanputModel model)
        {

            var fornecedor = fornecedorService.BuscarPorId(model.Id.Value);
            
            fornecedor.Nacional = model.Nacional;
            fornecedor.PessoaJuridica.DataContituicao = model.DataContituicao;
            fornecedor.PessoaJuridica.NomeFantasia = model.NomeFantasia;
            fornecedor.PessoaJuridica.RazaoSocial = model.RazaoSocial;
            fornecedor.PessoaJuridica.ValorQuota= model.ValorQuota;
            fornecedor.PessoaJuridica.CapitalSocial= model.CapitalSocial;
            fornecedor.PessoaJuridica.QuantidadeQuota= model.QuantidadeQuota;
            fornecedor.PessoaJuridica.Contato.EmailPrincipal = model.EmailPrincipal;
            fornecedor.PessoaJuridica.Contato.Website= model.Website;
            fornecedor.PessoaJuridica.Contato.Fone1= model.Fone1;
            fornecedor.PessoaJuridica.Contato.Fone2= model.Fone2;
            fornecedor.PessoaJuridica.Contato.Fone3= model.Fone3;
            fornecedor.PessoaJuridica.Caracterizacao= caracterizacaoCapitalService.BuscarPorId(model.Caracterizacao);
            fornecedor.PessoaJuridica.PorteEmpresa= porteService.BuscarPorId(model.PorteEmpresa);
            fornecedor.TipoEmpresa = tipoEmpresaService.BuscarPorId(model.TipoEmpresa);

            fornecedorService.Atualizar(fornecedor);
        }
        public void AtualizarPessoaFisica(FornecedorPessoaFisicaInputModel model)
        {

            var fornecedor = fornecedorService.BuscarPorId(model.Id.Value);
            
            fornecedor.TipoEmpresa = tipoEmpresaService.BuscarPorId(model.TipoEmpresa);
            fornecedor.Nacional = model.Nacional;
            fornecedor.PessoaFisica.Profissao = model.Profissao;
            fornecedor.PessoaFisica.Nacionalidade= model.Nacionalidade;
            fornecedor.PessoaFisica.Genero = (eGenero)Enum.Parse(typeof(eGenero),model.Genero);
            fornecedor.PessoaFisica.EstadoCivil = (eEstadoCivil)Enum.Parse(typeof(eEstadoCivil),model.EstadoCivil);
            fornecedor.PessoaFisica.Cpf= model.Cpf;
            fornecedor.PessoaFisica.DataNascimento= model.DataNascimento;
            fornecedor.PessoaFisica.Contato.EmailPrincipal = model.EmailPrincipal;
            fornecedor.PessoaFisica.Contato.Fone1= model.Fone1;
            fornecedor.PessoaFisica.Contato.Fone2= model.Fone2;
            fornecedor.PessoaFisica.Contato.Fone3= model.Fone3;

            fornecedorService.Atualizar(fornecedor);
        }

        public void Dispose()
        {
            tipoEmpresaService.Dispose();
            porteService.Dispose();
            caracterizacaoCapitalService.Dispose();
        }
    }
}
