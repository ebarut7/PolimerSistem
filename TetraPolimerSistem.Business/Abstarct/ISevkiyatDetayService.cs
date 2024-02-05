using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore;
using TetraPolimerSistem.Entities.Dtos.OrderDtos;
using TetraPolimerSistem.Entities.Dtos.SevkiyatDetayDtos;

namespace TetraPolimerSistem.Business.Abstarct
{
    public interface ISevkiyatDetayService
    {
        Task<List<SevkiyatDetayDto>> GetAllAsync();

        Task<int> DeleteAsync(int id);

        Task<int> AddAsync(SevkiyatAddDto sevkiyatAddDto);
        Task<int> UpdateAsync(SevkiyatDetayDto sevkiyatDetayDto);

        Task<List<SevkiyatDetayDto>> GetBySoforFilterAsync(string filter = "");

        Task<List<SevkiyatDetayDto>> GetByPlakaFilterAsync(string filter = "");
    }
}
