using CsharpCamada.API.DAL;
using CsharpCamada.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        protected readonly csharpCamadasContext _context;

        public MotoristaController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/Motorista")]
        public async Task<IActionResult> PegarTodosMotoristas()
        {
            try
            {
                var dados = await _context.Set<Motoristum>().ToListAsync();
                List<Motoristum> Lista = new List<Motoristum>();
                foreach (var item in dados)
                {
                    Motoristum Model = new Motoristum
                    {
                        MotId = item.MotId,
                        MotNome = item.MotNome,
                        MotIdade = item.MotIdade,
                        VeiId = item.VeiId,
                        Vei = await _context.Set<Veiculo>().FindAsync(item.VeiId),
                    };
                    Lista.Add(Model);
                }
                return Ok(Lista);
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex);
            }
        }

        [HttpGet("/Motorista/{id}")]

        public async Task<IActionResult> PegarMotoristaPorId(int id)
        {
            try
            {
                return Ok(await _context.Set<Motoristum>().FindAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um error: " + ex);
            }
        }

        [HttpPost("/Motorista/Create")]

        public async Task<IActionResult> CriarMotorista(Motoristum Model)
        {
            try
            {
                await _context.AddAsync(Model);
                await _context.SaveChangesAsync();
                return Ok("Motorista Criado");
            }
            catch (Exception ex)
            {

                return BadRequest("Não foi possivel criar o Motorista");
            }
        }

        [HttpPut("/Motorista/Atualizar")]

        public async Task<IActionResult> AtualizarMotorista(Motoristum Model)
        {
            try
            {
                _context.Update(Model);
                await _context.SaveChangesAsync();
                return Ok("Motorista Atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest("Motorista Atualizado");
            }
        }

        [HttpDelete("/Motorista/Remove/{id}")]

        public async Task<IActionResult> ApagarMotorista(int id)
        {
            try
            {
                var Model = await _context.Set<Motoristum>().FindAsync(id);
                _context.Remove(Model);
                await _context.SaveChangesAsync();
                return Ok("Motorista Apagado");
            }
            catch (Exception ex)
            {
                return BadRequest("Motorista não apagado");
            }
        }
    }
}
