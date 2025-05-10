using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.RESERVASPC01.CORE.CORE.Entities;
using UESAN.RESERVASPC01.CORE.CORE.Interfaces;

namespace UESAN.ReservasPC01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Canchas : ControllerBase
    {
        private readonly ICanchasRepository _canchasRepository;
        
        public Canchas(ICanchasRepository canchasRepository)
        {
            _canchasRepository = canchasRepository;
        }

        //get api/canchas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canchas>>> GetCanchas()
        {
            var canchas = await _canchasRepository.GetCanchas();
            return Ok(canchas);
        }
        //get api/canchas/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Canchas>> GetCanchas(int id)
        {
            var canchas = await _canchasRepository.GetCanchas(id);
            if (canchas == null)
            {
                return NotFound();
            }
            return Ok(canchas);
        }
        //post api/canchas
        [HttpPost]
        public async Task<ActionResult<Canchas>> PostCanchas(Canchas canchas)
        {
            if (canchas == null)
            {
                return BadRequest();
            }
            await _canchasRepository.AddCanchas(canchas);
            return CreatedAtAction(nameof(GetCanchas), new { id = canchas.Id }, canchas);
        }
        //put api/canchas/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Canchas>> PutCanchas(int id, Canchas canchas)
        {
            if (id != canchas.Id)
            {
                return BadRequest();
            }
            await _canchasRepository.UpdateCanchas(canchas);
            return NoContent();
        }

        //delete api/canchas/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canchas>> DeleteCanchas(int id)
        {
            var canchas = await _canchasRepository.GetCanchas(id);
            if (canchas == null)
            {
                return NotFound();
            }
            await _canchasRepository.DeleteCanchas(canchas);
            return NoContent();
        }
        //get api/canchas/tarifas
        [HttpGet("tarifas")]
        public
            async Task<ActionResult<IEnumerable<Tarifas>>> GetTarifas()
        {
            var tarifas = await _canchasRepository.GetTarifas();
            return Ok(tarifas);
        }
        //get api/canchas/tarifas/1
        [HttpGet("tarifas/{id}")]
        public async Task<ActionResult<Tarifas>> GetTarifas(int id)
        {
            var tarifas = await _canchasRepository.GetTarifas(id);
            if (tarifas == null)
            {
                return NotFound();
            }
            return Ok(tarifas);
        }
        //post api/canchas/tarifas
        [HttpPost("tarifas")]
        public async Task<ActionResult<Tarifas>> PostTarifas(Tarifas tarifas)
        {
            if (tarifas == null)
            {
                return BadRequest();
            }
            await _canchasRepository.AddTarifas(tarifas);
            return CreatedAtAction(nameof(GetTarifas), new { id = tarifas.Id }, tarifas);
        }

    }
}
