using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.DataAccess.EntityFrameworkCore;
using TetraPolimerSistem.DataAccess.Abstarct;
using TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore.Context;
using TetraPolimerSistem.Entities.Concrete;

namespace TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore
{
    public class DisTicaretDal : RepositoryBase<DisTicaret>,IDisTicaretDal
    {
        public DisTicaretDal(TetraPolimerSistemContext context):base(context)
        {
            
        }
    }
}
