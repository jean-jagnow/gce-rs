using GCE.Data.Configs.Cadastros;
using GCE.Data.Configs.Fornecedores;
using GCE.Domain.Cadastros;
using GCE.Domain.Fornecedores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Data
{
    public sealed class GCEContext: DbContext
    {
        public GCEContext() : base("GCELocalDb")
        {
        }

        public DbSet<CaracterizacaoCapital> CaracterizacaoCapital { get; set; }
        public DbSet<Porte> Porte { get; set; }
        public DbSet<TipoEmpresa> TiposDeEmpresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CaracterizacaoCapitalConfiguration());
            modelBuilder.Configurations.Add(new PorteConfiguration());
            modelBuilder.Configurations.Add(new TipoEmpresaConfiguration());

            modelBuilder.Configurations.Add(new FornecedorConfiguration());
            modelBuilder.Configurations.Add(new FornecedorPessoaFisicaConfiguration());
            modelBuilder.Configurations.Add(new FornecedorPessoaJuridicaConfiguration());
        }

    }
}
