using TetraPolimerSistem.Entities.Dtos.OrderDtos;

namespace TetraPolimerSistem.Business.Abstarct
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();

        Task<int> DeleteAsync(int id);

        Task<int> AddAsync(OrderAddDto orderAddDto);
        Task<int> UpdateAsync(OrderDto orderDto);

        Task<List<OrderDto>> GetByProformaFilterAsync(string filter = "");

        Task<List<OrderDto>> GetByFirmaFilterAsync(string filter = "");

        Task<List<OrderDto>> GetBySiparisFilterAsync(string filter = "Sipariş");

        Task<List<OrderDto>> GetBySevkBekleyenFilterAsync(string filter = "Yolda");

        Task<List<OrderDto>> GetByTeslimEdilenFilterAsync(string filter = "Teslim Edilen");


    }
}
