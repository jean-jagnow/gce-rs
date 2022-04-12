using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCE.Domain.Cadastros;
using GCE.Domain.Fornecedores;
using GCE.Domain.Fornecedores.Common;
namespace GCE.Data.Strategy
{
    internal class DbInit: System.Data.Entity.CreateDatabaseIfNotExists<GCEContext>
    {
        protected override void Seed(GCE.Data.GCEContext context)
        {
            if (!context.Porte.Any())
                context.Porte.AddRange(new Porte[]
                {
                    new Porte("Outros"),
                    new Porte("Nacional"),
                    new Porte("Continental")
                });

            if (!context.TiposDeEmpresas.Any())
                context.TiposDeEmpresas.AddRange(new TipoEmpresa[]
                {
                    new TipoEmpresa("LTDA - Limitada"),
                    new TipoEmpresa("Leiloeiro")
                });

            if (!context.CaracterizacaoCapital.Any())
                context.CaracterizacaoCapital.AddRange(new CaracterizacaoCapital[]
                {
                    new CaracterizacaoCapital("Outros"),
                    new CaracterizacaoCapital("Público"),
                    new CaracterizacaoCapital("Privado")
                });

            context.SaveChanges();

            if (!context.Fornecedores.Any())
                context.Fornecedores.AddRange(new Fornecedor[]
                {
                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "LTDA - Limitada"), true)
                        .NovoPessoaJuridica(
                            new PessoaJuridica("015717020000198", "HALEX INSTAR IND FARMACEUTICA LTDA",
                            "INSTAR",
                            context.Porte.Single(x => x.Descricao == "Outros"),
                            new ContatoPessoaJuridica("5133663806", "emal@ind.com"),
                            70*1000)),
                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "Leiloeiro"), true)
                        .NovoPessoaJuridica(
                            new PessoaJuridica("171625790000191", "LIDER TAXI AEREO S/A AIR BRASIL",
                            "TAXI",
                            context.Porte.Single(x => x.Descricao == "Outros"),
                            new ContatoPessoaJuridica("5133664522", "lidertx@ind.com"),
                            400*1000)),
                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "LTDA - Limitada"), true)
                        .NovoPessoaJuridica(
                            new PessoaJuridica("286720870000162", "SAING GOBAIN CANALIZAÇÃO LTDA",
                            "GOBAIN",
                            context.Porte.Single(x => x.Descricao == "Outros"),
                            new ContatoPessoaJuridica("54302809021", "saing1@ind.com"),
                            150*1000)),
                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "LTDA - Limitada"), true)
                        .NovoPessoaJuridica(
                            new PessoaJuridica("331133090000147", "VALID SOLUÇÕES E SERVIÇOS DE SEGURANÇA EM MEIOS",
                            "SEGURANÇA",
                            context.Porte.Single(x => x.Descricao == "Outros"),
                            new ContatoPessoaJuridica("543028090418", "valid@ind.com"),
                            150*400)),
                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "LTDA - Limitada"), true)
                        .NovoPessoaJuridica(
                            new PessoaJuridica("331310790000149", "CARL ZEISS DO BRASIL LTDA",
                            "ZEISS",
                            context.Porte.Single(x => x.Descricao == "Outros"),
                            new ContatoPessoaJuridica("553202548200", "carl@gmail.com"),
                            250*400)),

                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "Leiloeiro"), true)
                        .NovoPessoaFisica(new PessoaFisica("97672971034",
                        "Camila Lais Cargnelutti", "Montador", eGenero.Feminino, 
                        new Contato("5530216025", "cami@gmail.com"), new DateTime(1976,06,23))),
                    new Fornecedor(context.TiposDeEmpresas.Single(x => x.Descricao == "Leiloeiro"), true)
                        .NovoPessoaFisica(new PessoaFisica("09641688049",
                        "Ruy Garigham Pinto", "Soldador", eGenero.Masculino, 
                        new Contato("54992124216", "rp@gmail.com"), new DateTime(1976,06,23))),
                });
            try
            {
                context.SaveChanges();
            }catch(System.Data.Entity.Validation.DbEntityValidationException e)
            {
            }

        }
    }
}
