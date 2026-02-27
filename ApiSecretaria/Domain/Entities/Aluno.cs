namespace ApiSecretaria.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public int Semestre { get; set; }
        public string Email { get; set; }
        public DateTime DataIngresso { get; set; }
        public int Ra { get; set; }
    }
}
