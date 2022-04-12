using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCEApi.Models.InputModels
{
    public class FornecedorPessoaFisicaInputModel : IInput
    {
        public long? Id { get; set; }

        [Required]
        public long TipoEmpresa { get; set; }
        [Required]
        public bool Nacional { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Profissao { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }
        [Required]
        public string EmailPrincipal { get; set; }
        public string EstadoCivil { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
    }
}
