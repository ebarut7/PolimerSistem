using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Concrete;
using TetraPolimerSistem.Entities.Dtos.DisTicaretMaliyetDtos;
using TetraPolimerSistem.WEBUI.Models.ViewModels;

namespace TetraPolimerSistem.WEBUI.Controllers
{
    public class DisTicaretMaliyetController : Controller
    {
        private readonly IDisTicaretMaliyetService _disTicaretMaliyetService;
        List<DisTicaretMaliyetVM> disTicaretMaliyetVMs = new();

        public DisTicaretMaliyetController(IDisTicaretMaliyetService disTicaretMaliyetService)
        {
            _disTicaretMaliyetService = disTicaretMaliyetService;
            Doldur();
        }


        [HttpGet]

        public IActionResult MaliyetGuncelleme(int id)
        {
          DisTicaretMaliyetVM disTicaretMaliyetVM =  disTicaretMaliyetVMs.FirstOrDefault(x=>x.Id==id);
            return View(disTicaretMaliyetVM);
        }
        [HttpPost]

        public async Task<IActionResult> MaliyetGuncelleme(DisTicaretMaliyetDto disTicaretMaliyetDto)
        {
            var res= await _disTicaretMaliyetService.UpdateAsync(disTicaretMaliyetDto);
            return res > 0 ? RedirectToAction("DisTicaretler","DisTicaret") : View(disTicaretMaliyetDto);
        }

        [HttpGet]
        public async Task<IActionResult> MaliyetDetay(int id)
        {
            var disTicaretMaliyetVM= disTicaretMaliyetVMs.FirstOrDefault(x=>x.Id==id);
            return View(disTicaretMaliyetVM);
        }


        public async Task Doldur()
        {
            List<DisTicaretMaliyetDto> disTicaretMaliyetDtos = await _disTicaretMaliyetService.GetAllAsync();
            foreach (var item in disTicaretMaliyetDtos)
            {
                DisTicaretMaliyetVM disTicaretMaliyetVM = new DisTicaretMaliyetVM()
                {
                    BirimFiyat = item.BirimFiyat,
                    DamgaVergisi = item.DamgaVergisi,
                    Demuraj = item.Demuraj,
                    Diger = item.Diger,
                    DisTicaretId = item.DisTicaretId,
                    DovizMasraf = item.DovizMasraf,
                    GumrukKomisyon = item.GumrukKomisyon,
                    GumrukOran = item.GumrukOran,
                    GumrukVergisi = item.GumrukVergisi,
                    Id = item.Id,
                    KarliBirimFiyat = item.KarliBirimFiyat,
                    Kur = item.Kur,
                    LimanMasraf = item.LimanMasraf,
                    LokalMasraf = item.LokalMasraf,
                    MaliyetliBirimFiyat = item.MaliyetliBirimFiyat,
                    Nakliye = item.Nakliye,
                    OrdinoBedel = item.OrdinoBedel,
                    TLMasraf = item.TLMasraf,
                    ToplamDovizMaliyet = item.ToplamDovizMaliyet,
                    ToplamTLMaliyet = item.ToplamTLMaliyet,
                    UrunBedelDoviz = item.UrunBedelDoviz,
                    UrunBedelTL = item.UrunBedelTL,
                    UrunTonaj = item.UrunTonaj
                };
                disTicaretMaliyetVMs.Add(disTicaretMaliyetVM);
            }
        }
    }
}
