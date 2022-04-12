using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCEApi.Models.InputModels
{
    public class FornecedorPessoaJuridicanputModel : IInput
    {
        public long? Id { get; set; }
        [Required]
        public long TipoEmpresa { get; set; }
        [Required]
        public bool Nacional { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public long PorteEmpresa { get; set; }
        public string Website { get; set; }
        [Required]
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }
        [Required]
        public string EmailPrincipal { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime? DataContituicao { get; set; }
        public long Caracterizacao { get; set; }
        public decimal? QuantidadeQuota { get; set; }
        public decimal? ValorQuota { get; set; }
        [Required]
        public decimal CapitalSocial { get; set; }
    }
}
