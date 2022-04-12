using GCEApi.Models.InputModels;
using System.Linq;
using System.Web.Http;
using GCE.Application.Services;
using GCE.Domain.Fornecedores;
using GCEApi.Filters;
using GCEApi.Services;

namespace GCEApi.Controllers
{
    [RoutePrefix("api/fornecedor")]
    public class FornecedorController : GCEApiController
    {
        readonly FornecedorService service;
        public FornecedorController()
        {
            service = new FornecedorService();
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

        [HttpPost, Route("pessoa-fisica"), RequestValidate]
        public IHttpActionResult Post([FromBody]FornecedorPessoaFisicaInputModel model)
        {
            using (var manager = new FornecedorManager(service))
            {
                manager.CriarNovoPessoaFisica(model);
                return MapService(service.result);
            }                
        }

        [HttpPost, Route("pessoa-juridica"), RequestValidate]
        public IHttpActionResult Post([FromBody]FornecedorPessoaJuridicanputModel model)
        {
            using (var manager = new FornecedorManager(service))
            {
                manager.CriarNovoPessoaJuridica(model);
                return MapService(service.result);
            }                
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
