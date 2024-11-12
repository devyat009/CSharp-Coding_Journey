namespace SistemaBiblioteca.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Discriminator { get; set; }

    }
}