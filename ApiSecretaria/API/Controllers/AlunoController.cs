using ApiSecretaria.API.DTOs;
using ApiSecretaria.Domain.Entities;
using ApiSecretaria.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiSecretaria.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        // Construtor + Injeção de Dependencia
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost("CreateAluno")]
        public IActionResult CreateAluno(CreateAlunoDTO alunoDTO)
        {
            try
            {
                this._service.CreateAluno(alunoDTO);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("UpdateAluno")]
        public IActionResult UpdateAluno(Guid Id, Aluno aluno)
        {
            try
            {
                Aluno newAluno = this._service.GetById(Id);
                if (newAluno == null)
                {
                    return NotFound();
                }
                this._service.UpdateAluno(Id, aluno);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAluno")]
        public IActionResult DeleteAluno(Guid Id)
        {
            try
            {
                Aluno aluno = this._service.GetById(Id);
                if (aluno == null)
                {
                    return NotFound();
                }
                this._service.DeleteAluno(Id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Aluno aluno = this._service.GetById(Id);
                if (aluno == null)
                {
                    return NotFound();
                }
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<Aluno> alunos = this._service.GetAll();
            return Ok(alunos);
        }
    }
}
