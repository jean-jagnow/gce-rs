using GCE.Domain.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace GCE.Data.Configs.Fornecedores
{
    internal class FornecedorPessoaFisicaConfiguration : EntityTypeConfiguration<PessoaFisica>
    {
        public FornecedorPessoaFisicaConfiguration()
        {
            ToTable("fornecedores_pessoa_fisica");
            HasKey(x => x.Id);
            HasRequired(x => x.Fornecedor).WithRequiredPrincipal(x => x.PessoaFisica).WillCascadeOnDelete(true);
            Property(x => x.Cpf).HasMaxLength(14).IsRequired().HasColumnType("varchar").HasColumnName("cpf");
            HasIndex(x => x.Cpf).IsUnique(true);
            Property(x => x.Nome).HasMaxLength(80).IsRequired().HasColumnType("varchar");
            Property(x => x.Profissao).HasMaxLength(200).IsRequired().HasColumnType("varchar");
            Property(x => x.Nacionalidade).HasMaxLength(80).HasColumnType("varchar");
            Property(x => x.Genero).IsRequired();
            Property(x => x.DataNascimento).IsRequired();

            Property(x => x.Contato.EmailPrincipal).IsRequired().HasMaxLength(120).HasColumnType("varchar");
            Property(x => x.Contato.Fone1).IsRequired().HasMaxLength(20).HasColumnType("varchar");
            Property(x => x.Contato.Fone1).HasMaxLength(20).HasColumnType("varchar");
            Property(x => x.Contato.Fone3).HasMaxLength(20).HasColumnType("varchar");
        }
    }
}