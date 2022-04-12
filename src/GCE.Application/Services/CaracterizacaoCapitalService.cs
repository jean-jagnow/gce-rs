using GCE.Application.Common;
using GCE.Domain.Cadastros;
using System.Collections.Generic;
using System.Linq;

namespace GCE.Application.Services
{
    public class CaracterizacaoCapitalService: CrudService<CaracterizacaoCapital>
    {
        protected override void PodeSerAtualizado(CaracterizacaoCapital entity)
        {
            if (db.Any(x => x.Id != entity.Id && x.Descricao == entity.Descricao
                && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já uma caracterização {entity.Descricao} ativa registrada.");
        }

        protected override void PodeSerCadastrado(CaracterizacaoCapital entity)
        {
            if (db.Any(x => x.Descricao == entity.Descricao && x.Situacao == Domain.Common.eSituacao.Ativo))
                result.AddErro($"Já existe uma caracterização {entity.Descricao} ativa registrada.");

        }
    }
}
