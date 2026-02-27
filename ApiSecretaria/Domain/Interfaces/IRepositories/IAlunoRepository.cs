using ApiSecretaria.Domain.Entities;

namespace ApiSecretaria.Domain.Interfaces.IRepositories
{
    public interface IAlunoRepository
    {
        public void Create(Aluno aluno);
        public void Update(Guid Id, Aluno aluno);
        public void Delete(Guid Id);
        public Aluno GetById(Guid Id);
        public List<Aluno> GetAll();
    }
}
