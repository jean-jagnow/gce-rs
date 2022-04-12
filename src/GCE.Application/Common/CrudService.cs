using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCE.Application.Common
{
    public abstract class CrudService<TEntity>:BaseService<TEntity> where TEntity : Domain.Common.Entity
    {
        protected virtual void PodeSerAtualizado(TEntity entity) { }
        protected virtual void PodeSerCadastrado(TEntity entity) { }
        protected virtual void PodeSerExcluido(TEntity entity) { }
        protected virtual void PodeAlterarSituacao(TEntity entity) { }


        public IEnumerable<TEntity> ObterTodos()
            => db.AsNoTracking();

        public virtual TEntity BuscarPorId(long id)
        {
            return db.Find(id);
        }

        public virtual void Atualizar(TEntity entity)
        {
            PodeSerAtualizado(entity);

            if (IsValid)
                Commit();
        }
        public virtual void Cadastrar(TEntity entity)
        {
            PodeSerCadastrado(entity);

            if (IsValid)
            {
                db.Add(entity);
                Commit();
            }
        }
        public virtual void Excluir(TEntity entity)
        {
            PodeSerExcluido(entity);

            if (IsValid)
            {
                db.Remove(entity);
                Commit();
            }
        }

        public virtual void AlterarSituacao(long id, Domain.Common.eSituacao situacao)
        {
            var dado = db.Find(id);
            if (dado == null)
                throw new EntityNotFoundException();

            if (IsValid)
            {
                dado.Situacao = situacao;
                Commit();
            }
        }

    }
}
