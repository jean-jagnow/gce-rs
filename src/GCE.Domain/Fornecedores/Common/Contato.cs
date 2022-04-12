namespace GCE.Domain.Fornecedores.Common
{
    public class Contato
    {
        protected Contato()
        {
        }
        public Contato(string fone1, string emailPrincipal)
        {
            Fone1 = fone1;
            EmailPrincipal = emailPrincipal;
        }

        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Fone3 { get; set; }
        public string EmailPrincipal { get; set; }
    }
}