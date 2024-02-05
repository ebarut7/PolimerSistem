using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Dtos.OrderDtos;
using TetraPolimerSistem.WEBUI.Models.ViewModels;

namespace TetraPolimerSistem.WEBUI.Controllers
{
    public class SiparislerController : Controller
    {
        private readonly IOrderService _orderService;
        List<OrderVM> orderVMs = new();

        public SiparislerController(IOrderService orderService)
        {
            _orderService = orderService;
            Doldur();
        }

        public IActionResult Siparisler()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> SiparisDetay()
        {
            return View(orderVMs);
        }

        [HttpGet]

        public async Task<IActionResult> SevkBekleyen()
        {
            var siparisler = await _orderService.GetBySevkBekleyenFilterAsync();
            return View(siparisler);
        }


        [HttpGet]
        public async Task<IActionResult> TeslimEdilen()
        {
            var siparisler = await _orderService.GetByTeslimEdilenFilterAsync();
            return View(siparisler);
        }

        [HttpGet]

        public IActionResult SiparisEkleme()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SiparisEkleme(OrderAddDto orderAddDto)
        {
            var siparisEkleme = await _orderService.AddAsync(orderAddDto);
            return RedirectToAction("SiparisDetay");
        }

        [HttpGet]

        public IActionResult SiparisGuncelleme(int id)
        {
            OrderVM orderVM = orderVMs.FirstOrDefault(x=>x.Id==id);
            return View(orderVM);
        }

        [HttpPost]

        public async Task<IActionResult> SiparisGuncelleme(OrderDto orderDto)
        {
            var res= await _orderService.UpdateAsync(orderDto);
            return res > 0 ? RedirectToAction("SiparisDetay") : View(orderDto);
        }

        [HttpGet]

        public async Task<IActionResult> SiparisDetaylar(int id)
        {
            var orderVM= orderVMs.FirstOrDefault(x=>x.Id==id);
            return View(orderVM);
        }

        public async Task<IActionResult> Sil(int id)
        {
            int response = await _orderService.DeleteAsync(id);
            return response > 0 ? RedirectToAction("SiparisDetay") : RedirectToAction("SiparisDetaylar", new { id = id });
        }



        public async Task Doldur()
        {
            List<OrderDto> orderDtos = await _orderService.GetByProformaFilterAsync();
            foreach (var item in orderDtos)
            {
                OrderVM orderVM = new OrderVM()
                {
                    Aciklama = item.Aciklama,
                    BirimFiyat = item.BirimFiyat,
                    DovizCinsi = item.DovizCinsi,
                    Id = item.Id,
                    KDV = item.KDV,
                    Kur = item.Kur,
                    MaliyetDoviz = item.MaliyetDoviz,
                    MaliyetTL = item.MaliyetTL,
                    NakliyeTutar = item.NakliyeTutar,
                    ProformaNumara = item.ProformaNumara,
                    SevkDurumu = item.SevkDurumu,
                    SevkiyatDetayId = item.SevkiyatDetayId,
                    SevkTarihi = item.SevkTarihi,
                    SiparisAlanFirma = item.SiparisAlanFirma,
                    SiparisTarihi = item.SiparisTarihi,
                    SiparisVerenFirma = item.SiparisVerenFirma,
                    ToplamDovizMaliyet = item.ToplamDovizMaliyet,
                    ToplamTLMaliyet = item.ToplamTLMaliyet,
                    UrunAdi = item.UrunAdi,
                    UrunTonaj = item.UrunTonaj
                };
                orderVMs.Add(orderVM);
            }
        }
    }
}
