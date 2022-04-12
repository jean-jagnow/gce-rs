using GCE.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCEApi.Models.InputModels
{
    public class AlterarSituacaoInputModel:IInput
    {
        [Required]
        public eSituacao Situacao { get; set; }
        [Required]
        public long? Id { get; set; }
    }
}
