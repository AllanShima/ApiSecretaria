using ApiSecretaria.API.DTOs;
using ApiSecretaria.Domain.Entities;

namespace ApiSecretaria.Domain.Interfaces.IServices
{
    public interface IAlunoService
    {
        public void CreateAluno(CreateAlunoDTO aluno);
        public void UpdateAluno(Guid Id, Aluno aluno);
        public void DeleteAluno(Guid Id);
        public Aluno GetById(Guid Id);
        public List<Aluno> GetAll();
    }
}
