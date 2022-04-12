namespace GCE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.caracterizacoes_capital",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataDaUltimaAlteracao = c.DateTime(nullable: false),
                        Situacao = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.fornecedores_pessoa_juridica",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        cnpj = c.String(nullable: false, maxLength: 18, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 200, unicode: false),
                        Contato_Website = c.String(),
                        Contato_Fone1 = c.String(nullable: false, maxLength: 20, unicode: false),
                        Contato_Fone2 = c.String(),
                        Contato_Fone3 = c.String(maxLength: 20, unicode: false),
                        Contato_EmailPrincipal = c.String(nullable: false, maxLength: 120, unicode: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 200, unicode: false),
                        DataContituicao = c.DateTime(),
                        QuantidadeQuota = c.Decimal(precision: 18, scale: 2),
                        ValorQuota = c.Decimal(precision: 18, scale: 2),
                        CapitalSocial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Caracterizacao_Id = c.Long(nullable: false),
                        PorteEmpresa_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.caracterizacoes_capital", t => t.Caracterizacao_Id, cascadeDelete: true)
                .ForeignKey("dbo.portes", t => t.PorteEmpresa_Id, cascadeDelete: true)
                .Index(t => t.cnpj, unique: true)
                .Index(t => t.Caracterizacao_Id)
                .Index(t => t.PorteEmpresa_Id);
            
            CreateTable(
                "dbo.fornecedores",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Tipo = c.Short(nullable: false),
                        Nacional = c.Boolean(nullable: false),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataDaUltimaAlteracao = c.DateTime(nullable: false),
                        Situacao = c.Short(nullable: false),
                        TipoEmpresa_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.fornecedores_pessoa_fisica", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.tipos_de_empresas", t => t.TipoEmpresa_Id)
                .ForeignKey("dbo.fornecedores_pessoa_juridica", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.TipoEmpresa_Id);
            
            CreateTable(
                "dbo.fornecedores_pessoa_fisica",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        cpf = c.String(nullable: false, maxLength: 14, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 80, unicode: false),
                        Profissao = c.String(nullable: false, maxLength: 200, unicode: false),
                        Genero = c.Short(nullable: false),
                        Contato_Fone1 = c.String(nullable: false, maxLength: 20, unicode: false),
                        Contato_Fone2 = c.String(),
                        Contato_Fone3 = c.String(maxLength: 20, unicode: false),
                        Contato_EmailPrincipal = c.String(nullable: false, maxLength: 120, unicode: false),
                        EstadoCivil = c.Short(),
                        DataNascimento = c.DateTime(nullable: false),
                        Nacionalidade = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.cpf, unique: true);
            
            CreateTable(
                "dbo.tipos_de_empresas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataDaUltimaAlteracao = c.DateTime(nullable: false),
                        Situacao = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.portes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80, unicode: false),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataDaUltimaAlteracao = c.DateTime(nullable: false),
                        Situacao = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fornecedores_pessoa_juridica", "PorteEmpresa_Id", "dbo.portes");
            DropForeignKey("dbo.fornecedores", "Id", "dbo.fornecedores_pessoa_juridica");
            DropForeignKey("dbo.fornecedores", "TipoEmpresa_Id", "dbo.tipos_de_empresas");
            DropForeignKey("dbo.fornecedores", "Id", "dbo.fornecedores_pessoa_fisica");
            DropForeignKey("dbo.fornecedores_pessoa_juridica", "Caracterizacao_Id", "dbo.caracterizacoes_capital");
            DropIndex("dbo.fornecedores_pessoa_fisica", new[] { "cpf" });
            DropIndex("dbo.fornecedores", new[] { "TipoEmpresa_Id" });
            DropIndex("dbo.fornecedores", new[] { "Id" });
            DropIndex("dbo.fornecedores_pessoa_juridica", new[] { "PorteEmpresa_Id" });
            DropIndex("dbo.fornecedores_pessoa_juridica", new[] { "Caracterizacao_Id" });
            DropIndex("dbo.fornecedores_pessoa_juridica", new[] { "cnpj" });
            DropTable("dbo.portes");
            DropTable("dbo.tipos_de_empresas");
            DropTable("dbo.fornecedores_pessoa_fisica");
            DropTable("dbo.fornecedores");
            DropTable("dbo.fornecedores_pessoa_juridica");
            DropTable("dbo.caracterizacoes_capital");
        }
    }
}
