using APICliente.Models;
using APICliente.Exceptions;
using APICliente.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APICliente.Services.Interfaces;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Cliente> cliente = await _clienteService.GetAllClientes();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os clientes: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Cliente? cliente = await _clienteService.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar o cliente: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _clienteService.CreateCliente(clienteDTO);
                return CreatedAtAction(nameof(GetById), new { id = clienteDTO.Id }, clienteDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o cliente: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ClienteDTO clienteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                clienteDTO.Id = id;
                _clienteService.UpdateCliente(clienteDTO);
                return NoContent();
            }
            catch (ResourceNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o cliente: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteService.DeleteCliente(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao excluir o cliente: " + ex.Message);
            }
        }
    }
}
