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
    }
}
