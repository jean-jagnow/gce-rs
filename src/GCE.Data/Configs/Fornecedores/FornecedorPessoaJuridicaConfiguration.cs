using GCE.Domain.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace GCE.Data.Configs.Fornecedores
{
    internal class FornecedorPessoaJuridicaConfiguration : EntityTypeConfiguration<PessoaJuridica>
    {
        public FornecedorPessoaJuridicaConfiguration()
        {
            ToTable("fornecedores_pessoa_juridica");
            HasKey(x => x.Id);
            HasRequired(x => x.Fornecedor).WithRequiredPrincipal(x => x.PessoaJuridica).WillCascadeOnDelete(true);
            Property(x => x.Cnpj).HasMaxLength(18).IsRequired().HasColumnType("varchar").HasColumnName("cnpj");
            HasIndex(x => x.Cnpj).IsUnique(true);
            Property(x => x.RazaoSocial).HasMaxLength(200).IsRequired().HasColumnType("varchar");
            Property(x => x.NomeFantasia).HasMaxLength(200).IsRequired().HasColumnType("varchar");

            HasRequired(x => x.PorteEmpresa).WithMany(x => x.Fornecedores).WillCascadeOnDelete(true);
            HasRequired(x => x.Caracterizacao).WithMany(x => x.Fornecedores).WillCascadeOnDelete(true);

            Property(x => x.Contato.EmailPrincipal).IsRequired().HasMaxLength(120).HasColumnType("varchar");
            Property(x => x.Contato.Fone1).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            Property(x => x.Contato.Fone1).HasMaxLength(20).HasColumnType("varchar");
            Property(x => x.Contato.Fone3).HasMaxLength(20).HasColumnType("varchar");
        }
    }
}