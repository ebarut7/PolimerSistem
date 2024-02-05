using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Dtos.DisTicaretDtos;
using TetraPolimerSistem.Entities.Dtos.SevkiyatDetayDtos;

namespace TetraPolimerSistem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SevkiyatIdController : ControllerBase
    {
        private readonly ISevkiyatDetayService _sevkiyatDetayService;

        public SevkiyatIdController(ISevkiyatDetayService sevkiyatDetayService)
        {
            _sevkiyatDetayService = sevkiyatDetayService;
        }

        [HttpGet]

        public async Task<IActionResult> GetSevkiyatDetay()
        {
            List<SevkiyatDetayDto> sevkiyatDetayDtos = await _sevkiyatDetayService.GetAllAsync();
            return sevkiyatDetayDtos is null ? BadRequest() : Ok(sevkiyatDetayDtos);
        }

        [HttpPost]

        public async Task<IActionResult> AddSevkiyatDetay(SevkiyatAddDto sevkiyatAddDto)
        {
            int response = await _sevkiyatDetayService.AddAsync(sevkiyatAddDto);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateSevkiyatDetay(SevkiyatDetayDto sevkiyatDetayDto)
        {
            int response = await _sevkiyatDetayService.UpdateAsync(sevkiyatDetayDto);
            return response > 0 ? Ok("Guncelleme başarılı") : BadRequest("Guncelleme hatalı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSevkiyatDetay(int id)
        {
            int response = await _sevkiyatDetayService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
