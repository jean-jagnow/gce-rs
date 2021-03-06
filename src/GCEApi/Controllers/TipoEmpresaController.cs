using GCEApi.Models.InputModels;
using System.Linq;
using System.Web.Http;
using GCE.Application.Services;
using GCE.Domain.Cadastros;
using GCEApi.Filters;

namespace GCEApi.Controllers
{
    [RoutePrefix("api/tipo-empresa")]
    public class TipoEmpresaController : GCEApiController
    {
        readonly TipoEmpresaService service;
        public TipoEmpresaController()
        {
            service = new TipoEmpresaService();
        }

        [HttpGet, Route("")]
        public IHttpActionResult Listagem()
        {
            return Ok(service.ObterTodos().ToList());
        }

        [HttpPost, Route("alterar-situacao"), ValidaEntidade]
        public IHttpActionResult PostSituacao([FromBody] AlterarSituacaoInputModel model)
        {
            service.AlterarSituacao(model.Id.Value, model.Situacao);
            return MapService(service.result);
        }
        [HttpPost, Route(""), RequestValidate]
        public IHttpActionResult Post([FromBody]TipoEmpresaInputModel model)
        {
            service.Cadastrar(new TipoEmpresa(model.Descricao));
            return MapService(service.result);
        }
        
        [HttpPut, Route(""), ValidaEntidade]
        public IHttpActionResult Put(TipoEmpresaInputModel model)
        {
            var dado = service.BuscarPorId(model.Id.Value);
            dado.Descricao = model.Descricao;

            service.Atualizar(dado);
            return MapService(service.result);
        }
        
        [HttpDelete, Route(""), ValidaEntidade]
        public IHttpActionResult Delete(long id)
        {
            service.Excluir(service.BuscarPorId(id));
            return MapService(service.result);
        }


        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
