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

        [HttpGet("/Posto/{id}")]

        public async Task<IActionResult> PegarPostoPorId(int id)
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

        [HttpPost("/Posto/Create")]

        public async Task<IActionResult> CriarPosto(Posto Model)
        {
            try
            {
                await _context.AddAsync(Model);
                await _context.SaveChangesAsync();
                return Ok("Posto Criado");
            }
            catch (Exception ex)
            {

                return BadRequest("Não foi possivel criar o Posto");
            }
        }

        [HttpPut("/Posto/Atualizar")]

        public async Task<IActionResult> AtualizarPosto(Posto Model)
        {
            try
            {
                _context.Update(Model);
                await _context.SaveChangesAsync();
                return Ok("Posto Atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest("Posto Atualizado");
            }
        }

        [HttpDelete("/Posto/Remove/{id}")]

        public async Task<IActionResult> ApagarPosto(int id)
        {
            try
            {
                var Model = await _context.Set<Posto>().FindAsync(id);
                _context.Remove(Model);
                await _context.SaveChangesAsync();
                return Ok("Posto Apagado");
            }
            catch (Exception ex)
            {
                return BadRequest("Posto não apagado");
            }
        }
    }   }
