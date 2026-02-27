namespace ApiSecretaria.API.DTOs
{
    public class CreateAlunoDTO
    {
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Email { get; set; }
        public DateTime DataIngresso { get; set; }
    }
}
