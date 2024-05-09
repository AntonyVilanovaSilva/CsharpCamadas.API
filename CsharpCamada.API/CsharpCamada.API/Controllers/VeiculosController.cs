using CsharpCamada.API.DAL;
using CsharpCamada.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        protected readonly csharpCamadasContext _context;

        public VeiculosController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/Veículos")]
        public async Task<IActionResult> PegarTodosVeiculos()
        {
            try
            {
               return Ok(await _context.Set<Veiculo>().ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um error: " + ex);
            }
        }

        [HttpGet("/Veiculos/{id}")]

        public async Task<IActionResult> PegarVeiculoPorId(int id)
        {
            try
            {
                return Ok(await _context.Set<Veiculo>().FindAsync(id));
            } 
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um error: " + ex);
            }
        }

        [HttpPost("/Veiculos/Create")]

        public async Task<IActionResult> CriarVeiculos(Veiculo Model)
        {
            try
            {
                await _context.AddAsync(Model);
                await _context.SaveChangesAsync();
                return Ok("Veiculo Criado");
            }
            catch (Exception ex) {

                return BadRequest("Não foi possivel criar o veiculo");
            }
        }

        [HttpPut("/Veiculos/Atualizar")]

        public async Task<IActionResult> AtualizarVeiculo(Veiculo Model)
        {
            try
            {
               _context.Update(Model);
               await _context.SaveChangesAsync();
                return Ok("Veiculo Atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest("Veiculo Atualizado");
            }
        }

        [HttpDelete("/Veiculo/Remove/{id}")]

        public async Task<IActionResult> ApagarVeiculos(int id)
        {
            try
            {
                var Model = await _context.Set<Veiculo>().FindAsync(id);
                _context.Remove(Model);
                await _context.SaveChangesAsync();
                return Ok("Veiculo Apagado");
            }
            catch (Exception ex)
            {
                return BadRequest("Veiculo não apagado");
            }
        }

    }
}
