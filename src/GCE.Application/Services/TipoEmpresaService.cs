using GCE.Application.Common;
using GCE.Domain.Cadastros;
using System.Collections.Generic;
using System.Linq;

namespace GCE.Application.Services
{
    public class TipoEmpresaService : CrudService<TipoEmpresa>
    {
        protected override void PodeSerAtualizado(TipoEmpresa entity)
        {
            if (db.Any(x => x.Id != entity.Id && x.Descricao == entity.Descricao
                && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe um tipo de empresa {entity.Descricao} ativo registrado.");
        }

        protected override void PodeSerCadastrado(TipoEmpresa entity)
        {
            if (db.Any(x => x.Descricao == entity.Descricao && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe um tipo de empresa {entity.Descricao} ativo registrado.");

        }

    }
}
