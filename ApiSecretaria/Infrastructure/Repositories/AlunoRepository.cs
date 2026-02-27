using ApiSecretaria.Data;
using ApiSecretaria.Domain.Entities;
using ApiSecretaria.Domain.Interfaces.IRepositories;

namespace ApiSecretaria.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly Context _database;
        public AlunoRepository(Context context)
        {
            _database = context;
        }
        public void Create(Aluno aluno)
        {
            _database.Alunos.Add(aluno);
            _database.SaveChanges();
        }

        public void Update(Guid Id, Aluno aluno)
        {
            // Garante que o objeto tenha o ID passado na rota/parâmetro
            aluno.Id = Id;

            _database.Alunos.Update(aluno);
            _database.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            _database.Alunos.Remove(_database.Alunos.Where(aluno => aluno.Id == Id).FirstOrDefault());
            _database.SaveChanges();
        }
        public Aluno GetById(Guid Id)
        {
            return _database.Alunos.Select(aluno => aluno).Where(aluno => aluno.Id == Id).FirstOrDefault();
        }
        public List<Aluno> GetAll()
        {
            return this._database.Alunos.Select(aluno => aluno).ToList();
        }
    }
}
