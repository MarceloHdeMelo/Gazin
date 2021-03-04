using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Crud_Gazin.Models;
using API_Crud_Gazin.Aplicacao;
using Newtonsoft.Json;

namespace API_Crud_Gazin.Controllers
{
    [Route("api/developers")]
    [ApiController]
    [Produces("application/json")]
    public class DevelopersController : ControllerBase
    {
        private readonly ApiContext _contexto;

        public DevelopersController(ApiContext context)
        {
            _contexto = context;
        }

        [HttpGet]
        //[Route("ObterTodosDevelopers")]
        public IActionResult ObterTodosDevelopers()
        {
            try
            {
                var listaDeDevelopers = new DeveloperAplicacao(_contexto).ObterTodosDevelopers();

                if (listaDeDevelopers.Any())
                {
                    return Ok(listaDeDevelopers);
                }
                else
                {
                    return BadRequest("Nenhum developer cadastrado!");
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperDTO>> GetDeveloper(int id)
        {
            var developer = await _contexto.Developer.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }
            
            return DeveloperToDTO(developer);
            
        }

        [HttpPut("{id}")]
        //[HttpPut]
        //[Route("AtualizarDeveloper")]
        public IActionResult AtualizarDeveloper([FromBody] Developer developerEnviado)
        {
            try
            {
                if (!ModelState.IsValid || developerEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new DeveloperAplicacao(_contexto).AtualizarDeveloper(developerEnviado);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpPost]
        //[Route("InserirDeveloper")]
        public IActionResult InserirDeveloper([FromBody]Developer developerEnviado)
        {
            try
            {
                if (!ModelState.IsValid || developerEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new DeveloperAplicacao(_contexto).InserirDeveloper(developerEnviado);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeveloperDTO>> DeletarDeveloper(int id)
        {
            var developer = await _contexto.Developer.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _contexto.Developer.Remove(developer);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        private bool DeveloperExists(long id) =>
            _contexto.Developer.Any(e => e.Id == id);

        private static DeveloperDTO DeveloperToDTO(Developer developer) =>
            new DeveloperDTO
            {
                Id = developer.Id,
                Nome = developer.Nome,
                Sexo = developer.Sexo,
                Idade = developer.Idade,
                Hobby = developer.Hobby,
                DataNascimento = developer.DataNascimento
            };
    }
}
