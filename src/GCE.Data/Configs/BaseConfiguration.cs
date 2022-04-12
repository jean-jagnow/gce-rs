using GCE.Application.Common;
using System.Data.Entity.ModelConfiguration;

namespace GCE.Data.Configs
{
    public abstract class BaseConfiguration<T> : EntityTypeConfiguration<T> where T
        : Entity
    {
        public BaseConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.DataDeCriacao).IsRequired();
            Property(x => x.Situacao).IsRequired();
            Property(x => x.DataDaUltimaAlteracao).IsRequired();
        }
    }
}