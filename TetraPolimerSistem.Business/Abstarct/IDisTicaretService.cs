using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Entities.Dtos.DisTicaretDtos;

namespace TetraPolimerSistem.Business.Abstarct
{
    public interface IDisTicaretService
    {
        Task<List<DisTicaretDto>> GetByDosyaNumarasiFilterAsync(string filter = "");

        Task<List<DisTicaretDto>> GetByUrunAdiFilterAsync(string filter = "");

        Task<List<DisTicaretDto>> GetByIthalatFilterAsync(string filter = "Tetra");

        Task<List<DisTicaretDto>> GetByIhracatFilterAsync(string filter = "Tetra");

        Task<List<DisTicaretDto>> GetAllAsync();

        Task<int> DeleteAsync(int id);

        Task<int> AddAsync(DisTicaretAddDto disTicaretAddDto);
        Task<int> UpdateAsync(DisTicaretDto disTicaretDto);


    }
}
