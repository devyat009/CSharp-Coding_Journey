namespace SistemaBiblioteca.Domain.Exceptions
{
    public class DomainException
    {
        public List<string> Erros { get; set; } = new List<string>();

        public DomainException(string erro)
        {
            Erros.Add(erro);
        }

        //public override string Message { get => Erros.Aggregate("", (ultimo, atual) => ultimo + " " + atual); }
    }
}
