using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.DataAccess.Abstarct;
using TetraPolimerSistem.Entities.Concrete;
using TetraPolimerSistem.Entities.Dtos.DisTicaretMaliyetDtos;

namespace TetraPolimerSistem.Business.Concrete
{
    public class DisTicaretMaliyetManager : IDisTicaretMaliyetService
    {
        private readonly IDisTicaretMaliyetDal _disTicaretMaliyetDal;

        public DisTicaretMaliyetManager(IDisTicaretMaliyetDal disTicaretMaliyetDal)
        {
            _disTicaretMaliyetDal = disTicaretMaliyetDal;
        }

        public async Task<int> AddAsync(DisTicaretMaliyetAddDto disTicaretMaliyetAddDto)
        {
            DisTicaretMaliyet disTicaretMaliyet = new DisTicaretMaliyet()
            {
                DisTicaretId = disTicaretMaliyetAddDto.DisTicaretId,
                DamgaVergisi = disTicaretMaliyetAddDto.DamgaVergisi,
                Demuraj = disTicaretMaliyetAddDto.Demuraj,
                Diger = disTicaretMaliyetAddDto.Diger,
                GumrukOran = disTicaretMaliyetAddDto.GumrukOran,
                GumrukKomisyon = disTicaretMaliyetAddDto.GumrukKomisyon,
                GumrukVergisi = disTicaretMaliyetAddDto.GumrukVergisi,
                LimanMasraf = disTicaretMaliyetAddDto.LimanMasraf,
                LokalMasraf = disTicaretMaliyetAddDto.LokalMasraf,
                Kur = disTicaretMaliyetAddDto.Kur,
                OrdinoBedel = disTicaretMaliyetAddDto.OrdinoBedel,
                Nakliye = disTicaretMaliyetAddDto.Nakliye,
                BirimFiyat = disTicaretMaliyetAddDto.BirimFiyat,
                UrunTonaj = disTicaretMaliyetAddDto.UrunTonaj,
            };
            if (disTicaretMaliyetAddDto.GumrukVergisi < 1)
            {
                decimal oran = disTicaretMaliyetAddDto.GumrukOran / 100;
                decimal urunBedelDoviz = disTicaretMaliyetAddDto.UrunTonaj * disTicaretMaliyetAddDto.BirimFiyat;
                decimal urunBedelTL = urunBedelDoviz * disTicaretMaliyetAddDto.Kur;
                decimal sonuc = urunBedelTL * oran;
               disTicaretMaliyet.GumrukVergisi=disTicaretMaliyetAddDto.GumrukVergisi = sonuc;
            }
            else
            {
                disTicaretMaliyet.GumrukVergisi = disTicaretMaliyetAddDto.GumrukVergisi;
            }
            disTicaretMaliyetAddDto.UrunBedelDoviz = disTicaretMaliyetAddDto.UrunTonaj * disTicaretMaliyetAddDto.BirimFiyat;
            disTicaretMaliyetAddDto.UrunBedelTL = disTicaretMaliyetAddDto.UrunBedelDoviz * disTicaretMaliyetAddDto.Kur;
            decimal vergihesaplama = disTicaretMaliyetAddDto.GumrukVergisi + disTicaretMaliyetAddDto.GumrukKomisyon + disTicaretMaliyetAddDto.LimanMasraf + disTicaretMaliyetAddDto.LokalMasraf + disTicaretMaliyetAddDto.OrdinoBedel + disTicaretMaliyetAddDto.Nakliye + disTicaretMaliyetAddDto.Diger + disTicaretMaliyetAddDto.Demuraj + disTicaretMaliyetAddDto.DamgaVergisi;
            disTicaretMaliyetAddDto.TLMasraf = vergihesaplama;
            disTicaretMaliyetAddDto.DovizMasraf = disTicaretMaliyetAddDto.TLMasraf / disTicaretMaliyetAddDto.Kur;
            disTicaretMaliyetAddDto.ToplamTLMaliyet = disTicaretMaliyetAddDto.UrunBedelTL + disTicaretMaliyetAddDto.TLMasraf;
            disTicaretMaliyetAddDto.ToplamDovizMaliyet = disTicaretMaliyetAddDto.ToplamTLMaliyet / disTicaretMaliyetAddDto.Kur;
            disTicaretMaliyetAddDto.MaliyetliBirimFiyat = disTicaretMaliyetAddDto.ToplamDovizMaliyet / disTicaretMaliyetAddDto.UrunTonaj;

            disTicaretMaliyetAddDto.KarliBirimFiyat = disTicaretMaliyetAddDto.ToplamDovizMaliyet / disTicaretMaliyetAddDto.UrunTonaj + (30 / 100);


            disTicaretMaliyet.UrunBedelDoviz = disTicaretMaliyetAddDto.UrunBedelDoviz;
            disTicaretMaliyet.UrunBedelTL = disTicaretMaliyetAddDto.UrunBedelTL;
            disTicaretMaliyet.TLMasraf = disTicaretMaliyetAddDto.TLMasraf;
            disTicaretMaliyet.DovizMasraf = disTicaretMaliyetAddDto.DovizMasraf;
            disTicaretMaliyet.ToplamTLMaliyet = disTicaretMaliyetAddDto.ToplamTLMaliyet;
            disTicaretMaliyet.ToplamDovizMaliyet = disTicaretMaliyetAddDto.ToplamDovizMaliyet;
            disTicaretMaliyet.MaliyetliBirimFiyat = disTicaretMaliyetAddDto.MaliyetliBirimFiyat;
            disTicaretMaliyet.KarliBirimFiyat = disTicaretMaliyetAddDto.KarliBirimFiyat;


            await _disTicaretMaliyetDal.AddAsync(disTicaretMaliyet);
            return await _disTicaretMaliyetDal.SaveAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            DisTicaretMaliyet disTicaretMaliyet = await _disTicaretMaliyetDal.GetAsync(x => x.Id == id);
            await _disTicaretMaliyetDal.DeleteAsync(disTicaretMaliyet);
            return await _disTicaretMaliyetDal.SaveAsync();
        }

        public async Task<List<DisTicaretMaliyetDto>> GetAllAsync()
        {
            var disTicaretMaliyetler = await _disTicaretMaliyetDal.GetAllAsync();
            List<DisTicaretMaliyetDto> disTicaretMaliyetDtos = new List<DisTicaretMaliyetDto>();
            foreach (var item in disTicaretMaliyetler)
            {
                disTicaretMaliyetDtos.Add(new DisTicaretMaliyetDto()
                {
                    Id = item.Id,
                    UrunBedelDoviz = item.UrunBedelDoviz,
                    BirimFiyat = item.BirimFiyat,
                    DamgaVergisi = item.DamgaVergisi,
                    Demuraj = item.Demuraj,
                    Diger = item.Diger,
                    GumrukKomisyon = item.GumrukKomisyon,
                    GumrukOran = item.GumrukOran,
                    GumrukVergisi = item.GumrukVergisi,
                    Kur = item.Kur,
                    LimanMasraf = item.LimanMasraf,
                    LokalMasraf = item.LokalMasraf,
                    Nakliye = item.Nakliye,
                    OrdinoBedel = item.OrdinoBedel,
                    UrunTonaj = item.UrunTonaj,
                    TLMasraf = item.TLMasraf,
                    DovizMasraf = item.DovizMasraf,
                    UrunBedelTL = item.UrunBedelTL,
                    ToplamDovizMaliyet = item.ToplamDovizMaliyet,
                    ToplamTLMaliyet = item.ToplamTLMaliyet,
                    MaliyetliBirimFiyat = item.MaliyetliBirimFiyat,
                    KarliBirimFiyat = item.KarliBirimFiyat,
                });
            }
            return disTicaretMaliyetDtos;
        }

        public async Task<List<DisTicaretMaliyetDto>> MaliyetDosyaGetirAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x=>x.UrunTonaj.CompareTo(filter) >= 0).ToList();
        }

        public async Task<int> UpdateAsync(DisTicaretMaliyetDto disTicaretMaliyetDto)
        {
            DisTicaretMaliyet disTicaretMaliyet = await _disTicaretMaliyetDal.GetAsync(x => x.Id == disTicaretMaliyetDto.Id);
            disTicaretMaliyet.Kur = disTicaretMaliyetDto.Kur;
            disTicaretMaliyet.BirimFiyat = disTicaretMaliyetDto.BirimFiyat;
            disTicaretMaliyet.GumrukOran = disTicaretMaliyetDto.GumrukOran;
            disTicaretMaliyet.GumrukVergisi = disTicaretMaliyetDto.GumrukVergisi;
            disTicaretMaliyet.DamgaVergisi = disTicaretMaliyetDto.DamgaVergisi;
            disTicaretMaliyet.LokalMasraf = disTicaretMaliyetDto.LokalMasraf;
            disTicaretMaliyet.LimanMasraf = disTicaretMaliyetDto.LimanMasraf;
            disTicaretMaliyet.OrdinoBedel = disTicaretMaliyetDto.OrdinoBedel;
            disTicaretMaliyet.GumrukKomisyon = disTicaretMaliyetDto.GumrukKomisyon;
            disTicaretMaliyet.Nakliye = disTicaretMaliyetDto.Nakliye;
            disTicaretMaliyet.Demuraj = disTicaretMaliyetDto.Demuraj;
            disTicaretMaliyet.Diger = disTicaretMaliyetDto.Diger;
            disTicaretMaliyet.UrunTonaj = disTicaretMaliyetDto.UrunTonaj;

            if (disTicaretMaliyetDto.GumrukVergisi < 1)
            {
                decimal oran = disTicaretMaliyetDto.GumrukOran / 100;
                decimal urunBedelDoviz = disTicaretMaliyetDto.UrunTonaj * disTicaretMaliyetDto.BirimFiyat;
                decimal urunBedelTL = urunBedelDoviz * disTicaretMaliyetDto.Kur;
                decimal sonuc = urunBedelTL * oran;
               disTicaretMaliyet.GumrukVergisi= disTicaretMaliyetDto.GumrukVergisi = sonuc;
            }
            else
            {
                disTicaretMaliyet.GumrukVergisi = disTicaretMaliyetDto.GumrukVergisi;
            }

            disTicaretMaliyetDto.UrunBedelDoviz = disTicaretMaliyetDto.UrunTonaj * disTicaretMaliyetDto.BirimFiyat;
            disTicaretMaliyetDto.UrunBedelTL = disTicaretMaliyetDto.UrunBedelDoviz * disTicaretMaliyetDto.Kur;
            decimal vergihesaplama = disTicaretMaliyetDto.GumrukVergisi + disTicaretMaliyetDto.GumrukKomisyon + disTicaretMaliyetDto.LimanMasraf + disTicaretMaliyetDto.LokalMasraf + disTicaretMaliyetDto.OrdinoBedel + disTicaretMaliyetDto.Nakliye + disTicaretMaliyetDto.Diger + disTicaretMaliyetDto.Demuraj + disTicaretMaliyetDto.DamgaVergisi;
            disTicaretMaliyetDto.TLMasraf = vergihesaplama;
            disTicaretMaliyetDto.DovizMasraf = disTicaretMaliyetDto.TLMasraf / disTicaretMaliyetDto.Kur;
            disTicaretMaliyetDto.ToplamTLMaliyet = disTicaretMaliyetDto.UrunBedelTL + disTicaretMaliyetDto.TLMasraf;
            disTicaretMaliyetDto.ToplamDovizMaliyet = disTicaretMaliyetDto.ToplamTLMaliyet / disTicaretMaliyetDto.Kur;
            disTicaretMaliyetDto.MaliyetliBirimFiyat = disTicaretMaliyetDto.ToplamDovizMaliyet / disTicaretMaliyetDto.UrunTonaj;
            decimal karliBirim = 30 / 100;
            decimal karliBirimSonuc = disTicaretMaliyetDto.MaliyetliBirimFiyat + karliBirim;
            disTicaretMaliyetDto.KarliBirimFiyat = karliBirimSonuc;

            disTicaretMaliyet.UrunBedelDoviz = disTicaretMaliyetDto.UrunBedelDoviz;
            disTicaretMaliyet.UrunBedelTL = disTicaretMaliyetDto.UrunBedelTL;
            disTicaretMaliyet.TLMasraf = disTicaretMaliyetDto.TLMasraf;
            disTicaretMaliyet.DovizMasraf = disTicaretMaliyetDto.DovizMasraf;
            disTicaretMaliyet.ToplamTLMaliyet = disTicaretMaliyetDto.ToplamTLMaliyet;
            disTicaretMaliyet.ToplamDovizMaliyet = disTicaretMaliyetDto.ToplamDovizMaliyet;
            disTicaretMaliyet.MaliyetliBirimFiyat = disTicaretMaliyetDto.MaliyetliBirimFiyat;
            disTicaretMaliyet.KarliBirimFiyat = disTicaretMaliyetDto.KarliBirimFiyat;







            await _disTicaretMaliyetDal.UpdateAsync(disTicaretMaliyet);
            return await _disTicaretMaliyetDal.SaveAsync();

        }
    }
}
