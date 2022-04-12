namespace GCE.Domain.Fornecedores.Common
{
    public abstract class Detalhe
    {
        public long Id { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }
    }
}