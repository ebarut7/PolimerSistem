using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.DataAccess.Abstarct;
using TetraPolimerSistem.Entities.Concrete;
using TetraPolimerSistem.Entities.Dtos.DisTicaretDtos;

namespace TetraPolimerSistem.Business.Concrete
{
    public class DisTicaretManager : IDisTicaretService
    {
        private readonly IDisTicaretDal _disTicaretDal;

        public DisTicaretManager(IDisTicaretDal disTicaretDal)
        {
            _disTicaretDal = disTicaretDal;
        }

        public async Task<int> AddAsync(DisTicaretAddDto disTicaretAddDto)
        {

            DisTicaret disTicaret = new DisTicaret()
            {
                Aciklama = disTicaretAddDto.Aciklama,
                BeyannameNumarasi = disTicaretAddDto.BeyannameNumarasi,
                DosyaNumarasi = disTicaretAddDto.DosyaNumarasi,
                ETA = disTicaretAddDto.ETA,
                FaturaNumarasi = disTicaretAddDto.FaturaNumarasi,
                IhracatFirma = disTicaretAddDto.IhracatFirma,
                IthalatFirma = disTicaretAddDto.IthalatFirma,
                KonsimentoNumarasi = disTicaretAddDto.KonsimentoNumarasi,
                KonteynirNumarasi = disTicaretAddDto.KonteynirNumarasi,
                OdemeDurumu = disTicaretAddDto.OdemeDurumu,
                OdemeSekli = disTicaretAddDto.OdemeSekli,
                SatilabilirKisim = disTicaretAddDto.SatilabilirKisim,
                SiparisTarihi = disTicaretAddDto.SiparisTarihi,
                TeslimatYeri = disTicaretAddDto.TeslimatYeri,
                TeslimSekli = disTicaretAddDto.TeslimSekli,
                TeslimYeri = disTicaretAddDto.TeslimYeri,
                UrunAdi = disTicaretAddDto.UrunAdi,
                UrunTonaj = disTicaretAddDto.UrunTonaj,
                GirisYapanKullanici = disTicaretAddDto.GirisYapanKullanici,
                disTicaretMaliyet = new DisTicaretMaliyet()
                {
                    BirimFiyat = 0,
                    DamgaVergisi = 0,
                    Demuraj = 0,
                    Diger = 0,
                    DovizMasraf = 0,
                    GumrukKomisyon = 0,
                    GumrukOran = 0,
                    GumrukVergisi = 0,
                    KarliBirimFiyat = 0,
                    Kur = 0,
                    LimanMasraf = 0,
                    LokalMasraf = 0,
                    MaliyetliBirimFiyat = 0,
                    Nakliye = 0,
                    OrdinoBedel = 0,
                    TLMasraf = 0,
                    ToplamDovizMaliyet = 0,
                    ToplamTLMaliyet = 0,
                    UrunBedelDoviz = 0,
                    UrunBedelTL = 0,
                    UrunTonaj = 0,
                },

            };
            await _disTicaretDal.AddAsync(disTicaret);
            int res = await _disTicaretDal.SaveAsync();
            disTicaretAddDto.MaliyetId = disTicaret.disTicaretMaliyet.Id;
            disTicaret.MaliyetId = disTicaretAddDto.MaliyetId;
            await _disTicaretDal.UpdateAsync(disTicaret);
            if (res == 0)
            {
                _disTicaretDal.DeleteAsync(disTicaret);
            }
            return await _disTicaretDal.SaveAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            DisTicaret disTicaret = await _disTicaretDal.GetAsync(x => x.Id == id);
            await _disTicaretDal.DeleteAsync(disTicaret);
            return await _disTicaretDal.SaveAsync();
        }

        public async Task<List<DisTicaretDto>> GetAllAsync()
        {
            var disTicaretler = await _disTicaretDal.GetAllAsync();
            List<DisTicaretDto> disTicaretDtos = new List<DisTicaretDto>();
            foreach (var item in disTicaretler)
            {
                disTicaretDtos.Add(new DisTicaretDto
                {
                    BeyannameNumarasi = item.BeyannameNumarasi,
                    Aciklama = item.Aciklama,
                    DosyaNumarasi = item.DosyaNumarasi,
                    ETA = item.ETA,
                    FaturaNumarasi = item.FaturaNumarasi,
                    IhracatFirma = item.IhracatFirma,
                    IthalatFirma = item.IthalatFirma,
                    KonsimentoNumarasi = item.KonsimentoNumarasi,
                    KonteynirNumarasi = item.KonteynirNumarasi,
                    OdemeDurumu = item.OdemeDurumu,
                    OdemeSekli = item.OdemeSekli,
                    SatilabilirKisim = item.SatilabilirKisim,
                    SiparisTarihi = item.SiparisTarihi,
                    TeslimatYeri = item.TeslimatYeri,
                    TeslimSekli = item.TeslimSekli,
                    TeslimYeri = item.TeslimYeri,
                    UrunAdi = item.UrunAdi,
                    UrunTonaj = item.UrunTonaj,
                    Id = item.Id,
                    MaliyetId = item.MaliyetId,
                    GirisYapanKullanici = item.GirisYapanKullanici
                });
            }
            return disTicaretDtos;
        }

        public async Task<List<DisTicaretDto>> GetByDosyaNumarasiFilterAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x => x.DosyaNumarasi.Contains(filter)).ToList();
        }

        public async Task<List<DisTicaretDto>> GetByIhracatFilterAsync(string filter = "Tetra")
        {
            return (await GetAllAsync()).Where(x => x.IhracatFirma.Contains(filter)).ToList();
        }

        public async Task<List<DisTicaretDto>> GetByIthalatFilterAsync(string filter = "Tetra")
        {
            return (await GetAllAsync()).Where(x => x.IthalatFirma.Contains(filter)).ToList();
        }

        public async Task<List<DisTicaretDto>> GetByUrunAdiFilterAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x => x.UrunAdi.Contains(filter)).ToList();
        }

        public async Task<int> UpdateAsync(DisTicaretDto disTicaretDto)
        {
            DisTicaret disTicaret = await _disTicaretDal.GetAsync(x => x.Id == disTicaretDto.Id);
            disTicaret.ETA = disTicaretDto.ETA;
            disTicaret.IthalatFirma = disTicaretDto.IthalatFirma;
            disTicaret.IhracatFirma = disTicaretDto.IhracatFirma;
            disTicaret.FaturaNumarasi = disTicaretDto.FaturaNumarasi;
            disTicaret.OdemeDurumu = disTicaretDto.OdemeDurumu;
            disTicaret.DosyaNumarasi = disTicaretDto.DosyaNumarasi;
            disTicaret.KonteynirNumarasi = disTicaretDto.KonteynirNumarasi;
            disTicaret.UrunTonaj = disTicaretDto.UrunTonaj;
            disTicaret.BeyannameNumarasi = disTicaretDto.BeyannameNumarasi;
            disTicaret.SatilabilirKisim = disTicaretDto.SatilabilirKisim;
            disTicaret.OdemeSekli = disTicaretDto.OdemeSekli;
            disTicaret.UrunAdi = disTicaretDto.UrunAdi;
            disTicaret.TeslimatYeri = disTicaretDto.TeslimYeri;
            disTicaret.TeslimSekli = disTicaretDto.TeslimSekli;
            disTicaret.TeslimatYeri = disTicaretDto.TeslimatYeri;
            disTicaret.MaliyetId = disTicaretDto.MaliyetId;
            disTicaret.Aciklama = disTicaretDto.Aciklama;
            disTicaret.KonsimentoNumarasi = disTicaretDto.KonsimentoNumarasi;
            disTicaret.SiparisTarihi = disTicaretDto.SiparisTarihi;
            await _disTicaretDal.UpdateAsync(disTicaret);
            return await _disTicaretDal.SaveAsync();
        }
    }
}
