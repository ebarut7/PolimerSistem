using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.DataAccess.Abstarct;
using TetraPolimerSistem.Entities.Concrete;
using TetraPolimerSistem.Entities.Dtos.OrderDtos;
using TetraPolimerSistem.Entities.Dtos.SevkiyatDetayDtos;

namespace TetraPolimerSistem.Business.Concrete
{
    public class SevkiyatDetayManager : ISevkiyatDetayService
    {
        private readonly ISevkiyatDetayDal _sevkiyatDetayDal;

        public SevkiyatDetayManager(ISevkiyatDetayDal sevkiyatDetayDal)
        {
            _sevkiyatDetayDal = sevkiyatDetayDal;
        }

        public async Task<int> AddAsync(SevkiyatAddDto sevkiyatAddDto)
        {
            SevkiyatDetay sevkiyatDetay = new SevkiyatDetay()
            {
                Sofor = sevkiyatAddDto.Sofor,
                Plaka = sevkiyatAddDto.Plaka,
                TCKN = sevkiyatAddDto.TCKN,
                TelefonNumara = sevkiyatAddDto.TelefonNumara,
                Firma = sevkiyatAddDto.Firma,
                Aciklama = sevkiyatAddDto.Aciklama,
            };
            await _sevkiyatDetayDal.AddAsync(sevkiyatDetay);
            return await _sevkiyatDetayDal.SaveAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            SevkiyatDetay sevkiyatDetay = await _sevkiyatDetayDal.GetAsync(x => x.Id == id);
            await _sevkiyatDetayDal.DeleteAsync(sevkiyatDetay);
            return await _sevkiyatDetayDal.SaveAsync();
        }

        public async Task<List<SevkiyatDetayDto>> GetAllAsync()
        {
            var sevkiyatDetaylar=await _sevkiyatDetayDal.GetAllAsync();
            List<SevkiyatDetayDto> sevkiyatDetayDtos = new List<SevkiyatDetayDto>();
            foreach (var item in sevkiyatDetaylar)
            {
                sevkiyatDetayDtos.Add(new SevkiyatDetayDto()
                {
                     Sofor = item.Sofor,
                     Plaka = item.Plaka,
                     TCKN = item.TCKN,
                     TelefonNumara = item.TelefonNumara,
                     Firma = item.Firma,
                     Aciklama = item.Aciklama
                });
            }
            return sevkiyatDetayDtos;
        }

        public async Task<List<SevkiyatDetayDto>> GetByPlakaFilterAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x=>x.Plaka.Contains(filter)).ToList();
        }

        public async Task<List<SevkiyatDetayDto>> GetBySoforFilterAsync(string filter = "")
        {
            return (await GetAllAsync()).Where(x => x.Sofor.Contains(filter)).ToList();
        }

        public async Task<int> UpdateAsync(SevkiyatDetayDto sevkiyatDetayDto)
        {
            SevkiyatDetay sevkiyatDetay = await _sevkiyatDetayDal.GetAsync(x=>x.Id==sevkiyatDetayDto.Id);
            sevkiyatDetay.Sofor = sevkiyatDetayDto.Sofor;
            sevkiyatDetay.Plaka = sevkiyatDetayDto.Plaka;
            sevkiyatDetay.TCKN = sevkiyatDetayDto.TCKN;
            sevkiyatDetay.TelefonNumara = sevkiyatDetayDto.TelefonNumara;
            sevkiyatDetay.Firma = sevkiyatDetayDto.Firma;
            sevkiyatDetay.Aciklama = sevkiyatDetayDto.Aciklama;
            await _sevkiyatDetayDal.UpdateAsync(sevkiyatDetay);
            return await _sevkiyatDetayDal.SaveAsync();
        }


    }
}
