using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Shared.Response
{
    public class GCEResponse
    {
        public GCEResponse(IEnumerable<Erro> erros)
        {
            Erros = erros ?? new List<Erro>();
        }

        public bool Sucesso => !Erros.Any();
        public IEnumerable<Erro> Erros { get; set; }

        public class Erro
        {
            public string Codigo { get; set; }
            public string Mensagem { get; set; }
        }
    }
}
