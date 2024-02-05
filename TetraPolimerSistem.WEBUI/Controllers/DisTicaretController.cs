using Microsoft.AspNetCore.Mvc;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Dtos.DisTicaretDtos;
using TetraPolimerSistem.Entities.Dtos.DisTicaretMaliyetDtos;
using TetraPolimerSistem.WEBUI.Models.ViewModels;

namespace TetraPolimerSistem.WEBUI.Controllers
{
    public class DisTicaretController : Controller
    {
        private readonly IDisTicaretService _disTicaretService;
        private readonly IDisTicaretMaliyetService _disTicaretMaliyetService;
        List<DisTicaretVM> disTicaretVMs = new();


        public DisTicaretController(IDisTicaretService disTicaretService)
        {
            _disTicaretService = disTicaretService;
            Doldur();
        }

        [HttpGet]
        public IActionResult DisTicaretler()
        {
            return View(disTicaretVMs);
        }

        [HttpGet]
        public async Task<IActionResult> DisTicaretIthalat()
        {
            var disTicaretler = await _disTicaretService.GetByIthalatFilterAsync();
            return View(disTicaretler);
        }
        [HttpGet]

        public async Task<IActionResult> DisTicaretIhracat()
        {
            var disTicaretler = await _disTicaretService.GetByIhracatFilterAsync();
            return View(disTicaretler);
        }

        [HttpGet]

        public IActionResult DisTicaretEkleme()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> DisTicaretEkleme(DisTicaretAddDto disTicaretAddDto)
        {
            var disTicaretEkleme = await _disTicaretService.AddAsync(disTicaretAddDto);
            return RedirectToAction("DisTicaretIthalat");
        }

        [HttpGet]

        public IActionResult DisTicaretGuncelleme(int id)
        {
            DisTicaretVM disTicaretVM = disTicaretVMs.FirstOrDefault(x => x.Id == id);
            return View(disTicaretVM);
        }
        [HttpPost]

        public async Task<IActionResult> DisTicaretGuncelleme(DisTicaretDto disTicaretDto)
        {
            var res = await _disTicaretService.UpdateAsync(disTicaretDto);
            return res > 0 ? RedirectToAction("DisTicaretler") : View(disTicaretDto);
        }

        [HttpGet]

        public async Task<IActionResult> DisTicaretDetay(int id)
        {
            var disTicaretVM = disTicaretVMs.FirstOrDefault(x => x.Id == id);
            return View(disTicaretVM);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            int res = await _disTicaretService.DeleteAsync(id);
            return res > 0 ? RedirectToAction("DisTicaretler") : RedirectToAction("DisTicaretDetay", new { id = id });
        }






        public async Task Doldur()
        {
            List<DisTicaretDto> disTicaretDtos = await _disTicaretService.GetByDosyaNumarasiFilterAsync();
            foreach (var item in disTicaretDtos)
            {
                DisTicaretVM disTicaretVM = new DisTicaretVM()
                {
                    Aciklama = item.Aciklama,
                    BeyannameNumarasi = item.BeyannameNumarasi,
                    DosyaNumarasi = item.DosyaNumarasi,
                    ETA = item.ETA,
                    FaturaNumarasi = item.FaturaNumarasi,
                    GirisYapanKullanici = item.GirisYapanKullanici,
                    IhracatFirma = item.IhracatFirma,
                    IthalatFirma = item.IthalatFirma,
                    KonsimentoNumarasi = item.KonsimentoNumarasi,
                    KonteynirNumarasi = item.KonteynirNumarasi,
                    OdemeDurumu = item.OdemeDurumu,
                    Id = item.Id,
                    OdemeSekli = item.OdemeSekli,
                    SatilabilirKisim = item.SatilabilirKisim,
                    SiparisTarihi = item.SiparisTarihi,
                    TeslimatYeri = item.TeslimatYeri,
                    TeslimSekli = item.TeslimSekli,
                    TeslimYeri = item.TeslimatYeri,
                    UrunAdi = item.UrunAdi,
                    UrunTonaj = item.UrunTonaj,
                    MaliyetId = item.MaliyetId
                };
                disTicaretVMs.Add(disTicaretVM);
            }
        }

    }
}
