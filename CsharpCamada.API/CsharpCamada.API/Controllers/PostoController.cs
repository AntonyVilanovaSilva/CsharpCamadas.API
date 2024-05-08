using CsharpCamada.API.DAL;
using CsharpCamada.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsharpCamada.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostoController : ControllerBase
    {
        protected readonly csharpCamadasContext _context;

        public PostoController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/Posto")]
        public async Task<IActionResult> PegarTodosPostos()
        {
            try
            {
                var dadosPostos = await _context.Set<Posto>().ToListAsync();
                var dadosTipoCombustivel = await _context.Set<TiposDeCombustivel>().ToListAsync();
                List<Posto> Lista = new List<Posto>();
                foreach (var item in dadosPostos)
                {
                    Posto Model = new Posto
                    {
                        PosId = item.PosId,
                        PosNome = item.PosNome,
                        PosCidade = item.PosCidade,
                        PosEndereco = item.PosEndereco,
                        TiposDeCombustivels = dadosTipoCombustivel.Where(x => x.PosId == item.PosId).ToList(),
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
}   }
