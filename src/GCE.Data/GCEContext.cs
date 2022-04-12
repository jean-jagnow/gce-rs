using GCE.Data.Configs.Cadastros;
using GCE.Data.Configs.Fornecedores;
using GCE.Domain.Cadastros;
using GCE.Domain.Fornecedores;
using System;
using System.Data.Entity;
using System.Linq;
using GCE.Domain.Common;

namespace GCE.Data
{
    public sealed class GCEContext: DbContext
    {
        public GCEContext() : base("GCELocalDb")
        {
            Database.SetInitializer(new Strategy.DbInit());
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

        public override int SaveChanges()
        {
            foreach(var item in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified))
            {
                if(item.Entity is Entity)
                {
                    var entity = item.Entity as Entity;
                    entity.DataDaUltimaAlteracao = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
