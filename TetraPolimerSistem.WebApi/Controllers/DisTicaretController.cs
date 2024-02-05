using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Dtos.DisTicaretDtos;
using TetraPolimerSistem.Entities.Dtos.DisTicaretMaliyetDtos;

namespace TetraPolimerSistem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisTicaretController : ControllerBase
    {
        private readonly IDisTicaretService _disTicaretService;

        public DisTicaretController(IDisTicaretService disTicaretService)
        {
            _disTicaretService = disTicaretService;
        }

        [HttpGet]

        public async Task<IActionResult> GetDisTicaret()
        {
            List<DisTicaretDto> disTicaretDtos = await _disTicaretService.GetAllAsync();
            return disTicaretDtos is null ? BadRequest() : Ok(disTicaretDtos);
        }

        [HttpPost]

        public async Task<IActionResult> AddDisTicaret(DisTicaretAddDto disTicaretAddDto)
        {
            int response = await _disTicaretService.AddAsync(disTicaretAddDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDisTicaret(DisTicaretDto disTicaretDto)
        {
            int response = await _disTicaretService.UpdateAsync(disTicaretDto);
            return response > 0 ? Ok("Guncelleme başarılı") : BadRequest("Guncelleme hatalı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDisTicaretMaliyet(int id)
        {
            int response = await _disTicaretService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
