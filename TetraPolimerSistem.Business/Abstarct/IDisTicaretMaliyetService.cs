using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Entities.Dtos.DisTicaretDtos;
using TetraPolimerSistem.Entities.Dtos.DisTicaretMaliyetDtos;

namespace TetraPolimerSistem.Business.Abstarct
{
    public interface IDisTicaretMaliyetService
    {
        Task<List<DisTicaretMaliyetDto>> GetAllAsync();

        Task<int> DeleteAsync(int id);

        Task<int> AddAsync(DisTicaretMaliyetAddDto disTicaretMaliyetAddDto);
        Task<int> UpdateAsync(DisTicaretMaliyetDto disTicaretMaliyetDto);

        Task<List<DisTicaretMaliyetDto>> MaliyetDosyaGetirAsync(string filter = "");

    }
}
