using GCE.Data;
using System;
using System.Data.Entity;

namespace GCE.Application.Common
{
    public abstract class BaseService<TEntity>:IDisposable where TEntity: GCE.Domain.Common.Entity
    {
        readonly GCEContext context;
        protected DbSet<TEntity> db;
        public readonly ServiceResult result;
        protected BaseService()
        {
            this.context = new GCEContext();
            db = context.Set<TEntity>();
            result = new ServiceResult();
        }

        protected void Commit()
        {
            try
            {
                context.SaveChanges();
            }catch(Exception e)
            {
                result.AddErro("Ocorreu um erro ao salvar o registro. Contate o administrador.");
            }
        }

        protected bool IsValid => result.Type != ServiceResult.ResultType.Error;
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
