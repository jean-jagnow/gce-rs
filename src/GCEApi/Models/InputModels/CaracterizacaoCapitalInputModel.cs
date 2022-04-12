using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCEApi.Models.InputModels
{
    public class CaracterizacaoCapitalInputModel: IInput
    {
        public long? Id { get; set; }

        [DisplayName("Descrição"), Required(ErrorMessage = "Informe uma descrição"), MaxLength(80)]
        public string Descricao { get; set; }
    }
}
