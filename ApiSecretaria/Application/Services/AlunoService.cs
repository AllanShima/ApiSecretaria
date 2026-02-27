using ApiSecretaria.API.DTOs;
using ApiSecretaria.Domain.Entities;
using ApiSecretaria.Domain.Interfaces.IRepositories;
using ApiSecretaria.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;

namespace ApiSecretaria.Application.Services
{
    public class AlunoService : IAlunoService
    {
        // Constructor + I.D.
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public void CreateAluno(CreateAlunoDTO alunoDTO)
        {
            try
            {
                Aluno newAluno = new Aluno();

                // Regras de Negocio

                if (alunoDTO.Nome == null)
                {
                    throw new Exception("O nome do aluno é obrigatório");
                }
                if (alunoDTO.Nome.Length > 50)
                {
                    throw new Exception("O nome deve ter no máximo 50 caracteres.");
                }
                if (!alunoDTO.Email.EndsWith("@faculdade.edu"))
                {
                    throw new Exception("Email não válido.");
                }

                List<Aluno> alunos = this._repository.GetAll();
                foreach (Aluno aluno in alunos)
                {
                    if (aluno.Email == alunoDTO.Email)
                    {
                        throw new Exception("Email já cadastrado.");
                    }
                }

                newAluno.Nome = alunoDTO.Nome;
                newAluno.Curso = alunoDTO.Curso;
                newAluno.Email = alunoDTO.Email;
                newAluno.DataIngresso = alunoDTO.DataIngresso;

                newAluno.Ra = 1;

                this._repository.Create(newAluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }    
        }

        public void UpdateAluno(Guid Id, Aluno aluno)
        {
            try
            {
                Aluno newAluno = this._repository.GetById(Id);
                if (newAluno == null)
                {
                    throw new Exception("Aluno não encontrado.");
                }
                newAluno.Curso = aluno.Curso;
                newAluno.Nome = aluno.Nome;
                newAluno.Semestre = aluno.Semestre;
                newAluno.DataIngresso = aluno.DataIngresso;

                this._repository.Update(Id, newAluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAluno(Guid Id)
        {
            try
            {
                Aluno aluno = this._repository.GetById(Id);
                if (aluno == null)
                {
                    throw new Exception("User not found");
                }
                this._repository.Delete(Id);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Aluno GetById(Guid Id)
        {
            try
            {
                Aluno aluno = this._repository.GetById(Id);
                if (aluno == null)
                {
                    return null;
                }
                return aluno;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Aluno> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}
