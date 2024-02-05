using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Dtos.DisTicaretMaliyetDtos;

namespace TetraPolimerSistem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisTicaretMaliyetController : ControllerBase
    {
        private readonly IDisTicaretMaliyetService _disTicaretMaliyetService;

        public DisTicaretMaliyetController(IDisTicaretMaliyetService disTicaretMaliyetService)
        {
            _disTicaretMaliyetService = disTicaretMaliyetService;
        }

        [HttpPost]

        public async Task<IActionResult> AddDisTicaretMaliyet(DisTicaretMaliyetAddDto disTicaretMaliyetAddDto)
        {
            int response = await _disTicaretMaliyetService.AddAsync(disTicaretMaliyetAddDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDisTicaretMaliyet(DisTicaretMaliyetDto disTicaretMaliyetDto)
        {
            int response= await _disTicaretMaliyetService.UpdateAsync(disTicaretMaliyetDto);
            return response > 0 ? Ok("Guncelleme başarılı") : BadRequest("Guncelleme hatalı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDisTicaretMaliyet(int id)
        {
            int response= await _disTicaretMaliyetService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet]

        public async Task<IActionResult> GetDisTicaretMaliyet()
        {
            List<DisTicaretMaliyetDto> disTicaretMaliyetDtos= await _disTicaretMaliyetService.GetAllAsync();
            return disTicaretMaliyetDtos is null ? BadRequest() : Ok(disTicaretMaliyetDtos);
        }
    }
}
