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
                return BadRequest("error: " + ex);
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

    }
}
