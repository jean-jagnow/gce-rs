using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Application.Common
{
    public class ServiceResult
    {
        public ResultType Type { get; set; }
        public List<Content> Mensagens { get; set; } = new List<Content>();
        public enum ResultType
        {
            Success,
            Error
        }
        public class Content
        {
            public string Mensagem { get; set; }
            public string Codigo { get; set; }
        }

        public void AddErro(string mensagem)
        {
            Type = ResultType.Error;
            Mensagens.Add(new Content { Mensagem = mensagem});
        }
    }
}
