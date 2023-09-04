using APICliente.Models;
using APICliente.Models.DTO;
using APICliente.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APICliente.Services.Interfaces;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;

        public LogradouroController(ILogradouroService logradouroService)
        {
            _logradouroService = logradouroService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Logradouro> logradouro = await _logradouroService.GetAllLogradourosAsync();
                return Ok(logradouro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os logradouros: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Logradouro? logradouro = await _logradouroService.GetLogradouroByIdAsync(id);
                if(logradouro == null) 
                { 
                    return NotFound(); 
                }
                return Ok(logradouro);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar o logradouro: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] LogradouroDTO logradouroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _logradouroService.CreateLogradouro(logradouroDTO);
                return CreatedAtAction(nameof(GetById), new { id = logradouroDTO.Id }, logradouroDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o logradouro: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LogradouroDTO logradouroDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                logradouroDTO.Id = id;
                _logradouroService.UpdateLogradouro(logradouroDTO);
                return NoContent();
            }
            catch (ResourceNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o logradouro: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logradouroService.DeleteLogradouro(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao excluir o logradouro: " + ex.Message);
            }
        }
    }
}
