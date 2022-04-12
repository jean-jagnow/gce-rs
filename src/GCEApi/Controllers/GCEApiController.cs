using GCE.Application.Common;
using GCE.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace GCEApi.Controllers
{
    public abstract class GCEApiController:ApiController
    {
        protected IHttpActionResult MapService(ServiceResult serviceResult)
        {
            var result = new GCEResponse(serviceResult.Mensagens.Select(x => new GCEResponse.Erro
            {
                Codigo = x.Codigo,
                Mensagem = x.Mensagem
            }));

            if (serviceResult.Type == ServiceResult.ResultType.Error)
            {
                return Content(statusCode: System.Net.HttpStatusCode.BadGateway, result);
            }
            
            return Ok(result);
        }
    }
}
