using GCE.Application.Common;
using GCE.Domain.Cadastros;
using System.Collections.Generic;
using System.Linq;

namespace GCE.Application.Services
{
    public class PorteService : CrudService<Porte>
    {
        protected override void PodeSerAtualizado(Porte entity)
        {
            if (db.Any(x => x.Id != entity.Id && x.Descricao == entity.Descricao
                && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe um porte {entity.Descricao} ativo registrado.");
        }

        protected override void PodeSerCadastrado(Porte entity)
        {
            if (db.Any(x => x.Descricao == entity.Descricao && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe porte {entity.Descricao} ativo registrado.");

        }
    }
}
