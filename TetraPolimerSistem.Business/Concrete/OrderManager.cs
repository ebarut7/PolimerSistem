using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.DataAccess.Abstarct;
using TetraPolimerSistem.Entities.Concrete;
using TetraPolimerSistem.Entities.Dtos.OrderDtos;

namespace TetraPolimerSistem.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<int> AddAsync(OrderAddDto orderAddDto)
        {
            Order order = new Order()
            {
                ProformaNumara = orderAddDto.ProformaNumara,
                SiparisVerenFirma = orderAddDto.SiparisVerenFirma,
                SiparisAlanFirma = orderAddDto.SiparisAlanFirma,
                SiparisTarihi = orderAddDto.SiparisTarihi,
                SevkTarihi = orderAddDto.SevkTarihi,
                Kur = orderAddDto.Kur,
                DovizCinsi = orderAddDto.DovizCinsi,
                UrunTonaj = orderAddDto.UrunTonaj,
                UrunAdi = orderAddDto.UrunAdi,
                SevkDurumu = orderAddDto.SevkDurumu,
                BirimFiyat = orderAddDto.BirimFiyat,
                SevkiyatDetayId = orderAddDto.SevkiyatDetayId,
                NakliyeTutar = orderAddDto.NakliyeTutar,
                Aciklama = orderAddDto.Aciklama,
                KDV = orderAddDto.KDV,
            };
            orderAddDto.MaliyetDoviz = orderAddDto.BirimFiyat * orderAddDto.UrunTonaj;
            orderAddDto.MaliyetTL = orderAddDto.MaliyetDoviz * orderAddDto.Kur;
            if (orderAddDto.KDV > 0)
            {
                decimal kdvli = orderAddDto.KDV / 100;
                decimal dovizkdvli = orderAddDto.MaliyetDoviz * kdvli;
                orderAddDto.ToplamDovizMaliyet = orderAddDto.MaliyetDoviz + dovizkdvli;
                orderAddDto.ToplamTLMaliyet = orderAddDto.ToplamDovizMaliyet * orderAddDto.Kur;
            }
            else
            {
                orderAddDto.ToplamDovizMaliyet = orderAddDto.MaliyetDoviz;
                orderAddDto.ToplamTLMaliyet = orderAddDto.MaliyetTL;
            }

            order.ToplamTLMaliyet = orderAddDto.ToplamTLMaliyet;
            order.ToplamDovizMaliyet = orderAddDto.ToplamDovizMaliyet;
            order.MaliyetTL = orderAddDto.MaliyetTL;
            order.MaliyetDoviz = orderAddDto.MaliyetDoviz;
            await _orderDal.AddAsync(order);
            return await _orderDal.SaveAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            Order order = await _orderDal.GetAsync(x => x.Id == id);
            await _orderDal.DeleteAsync(order);
            return await _orderDal.SaveAsync();
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var siparisler = await _orderDal.GetAllAsync();
            List<OrderDto> orderDtos = new List<OrderDto>();
            foreach (var item in siparisler)
            {
                orderDtos.Add(new OrderDto()
                {
                    Id = item.Id,
                    ProformaNumara = item.ProformaNumara,
                    SiparisVerenFirma = item.SiparisVerenFirma,
                    SiparisAlanFirma = item.SiparisAlanFirma,
                    SiparisTarihi = item.SiparisTarihi,
                    SevkTarihi = item.SevkTarihi,
                    Kur = item.Kur,
                    DovizCinsi = item.DovizCinsi,
                    UrunTonaj = item.UrunTonaj,
                    UrunAdi = item.UrunAdi,
                    SevkDurumu = item.SevkDurumu,
                    BirimFiyat = item.BirimFiyat,
                    SevkiyatDetayId = item.SevkiyatDetayId,
                    NakliyeTutar = item.NakliyeTutar,
                    Aciklama = item.Aciklama,
                    KDV = item.KDV,
                    ToplamTLMaliyet = item.ToplamTLMaliyet,
                    ToplamDovizMaliyet = item.ToplamDovizMaliyet,
                    MaliyetTL = item.MaliyetTL,
                    MaliyetDoviz = item.MaliyetDoviz
                });
            }
            return orderDtos;
        }

        public async Task<List<OrderDto>> GetByFirmaFilterAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x => x.SiparisVerenFirma.Contains(filter)).ToList();
        }

        public async Task<List<OrderDto>> GetByProformaFilterAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x => x.ProformaNumara.Contains(filter)).ToList();
        }

        public async Task<List<OrderDto>> GetBySevkBekleyenFilterAsync(string filter = "Yolda")
        {
            return (await GetAllAsync()).Where(x => x.SevkDurumu.Contains(filter)).ToList();
        }

        public async Task<List<OrderDto>> GetBySiparisFilterAsync(string filter = "Sipariş")
        {
            return (await GetAllAsync()).Where(x => x.SevkDurumu.Contains(filter)).ToList();
        }

        public async Task<List<OrderDto>> GetByTeslimEdilenFilterAsync(string filter = "Teslim Edilen")
        {
            return (await GetAllAsync()).Where(x => x.SevkDurumu.Contains(filter)).ToList();
        }

        public async Task<int> UpdateAsync(OrderDto orderDto)
        {
            Order order = await _orderDal.GetAsync(x => x.Id == orderDto.Id);
            order.ProformaNumara = orderDto.ProformaNumara;
            order.SiparisVerenFirma = orderDto.SiparisVerenFirma;
            order.SiparisAlanFirma = orderDto.SiparisAlanFirma;
            order.SiparisTarihi = orderDto.SiparisTarihi;
            order.SevkTarihi = orderDto.SevkTarihi;
            order.Kur = orderDto.Kur;
            order.DovizCinsi = orderDto.DovizCinsi;
            order.UrunTonaj = orderDto.UrunTonaj;
            order.UrunAdi = orderDto.UrunAdi;
            order.SevkDurumu = orderDto.SevkDurumu;
            order.BirimFiyat = orderDto.BirimFiyat;
            order.SevkiyatDetayId = orderDto.SevkiyatDetayId;
            order.NakliyeTutar = orderDto.NakliyeTutar;
            order.Aciklama = orderDto.Aciklama;
            order.KDV = orderDto.KDV;
            orderDto.MaliyetDoviz = orderDto.BirimFiyat * orderDto.UrunTonaj;
            orderDto.MaliyetTL = orderDto.MaliyetDoviz * orderDto.Kur;
            if (orderDto.KDV > 0)
            {
                decimal kdvli = orderDto.KDV / 100;
                decimal dovizkdvli = orderDto.MaliyetDoviz * kdvli;
                orderDto.ToplamDovizMaliyet = orderDto.MaliyetDoviz + dovizkdvli;
                orderDto.ToplamTLMaliyet = orderDto.ToplamDovizMaliyet * orderDto.Kur;
            }
            else
            {
                orderDto.ToplamDovizMaliyet = orderDto.MaliyetDoviz;
                orderDto.ToplamTLMaliyet = orderDto.MaliyetTL;
            }
            order.ToplamTLMaliyet = orderDto.ToplamTLMaliyet;
            order.ToplamDovizMaliyet = orderDto.ToplamDovizMaliyet;
            order.MaliyetTL = orderDto.MaliyetTL;
            order.MaliyetDoviz = orderDto.MaliyetDoviz;

            await _orderDal.UpdateAsync(order);
            return await _orderDal.SaveAsync();
        }
    }
}
