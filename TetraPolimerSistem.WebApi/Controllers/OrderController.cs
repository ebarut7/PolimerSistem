using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Dtos.OrderDtos;

namespace TetraPolimerSistem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderAddDto orderAddDto)
        {
            int response=await _orderService.AddAsync(orderAddDto);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderDto orderDto)
        {
            int response=await _orderService.UpdateAsync(orderDto);
            return response > 0 ? Ok("Güncelleme başarılı.") : BadRequest("Güncelleme sırasında hata oluştu");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<OrderDto> orderDtos = await _orderService.GetAllAsync();
            return orderDtos is null ? BadRequest() : Ok(orderDtos);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int response= await _orderService.DeleteAsync(id);
            return Ok(response);
        }

    }
}
