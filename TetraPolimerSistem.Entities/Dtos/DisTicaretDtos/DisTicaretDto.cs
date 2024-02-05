using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.Entities;

namespace TetraPolimerSistem.Entities.Dtos.DisTicaretDtos
{
    public class DisTicaretDto : IDto
    {
        public int Id { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public string IthalatFirma { get; set; }

        public string IhracatFirma { get; set; }

        public string KonsimentoNumarasi { get; set; }

        public string KonteynirNumarasi { get; set; }

        public string BeyannameNumarasi { get; set; }

        public string DosyaNumarasi { get; set; }

        public decimal UrunTonaj { get; set; }

        public string FaturaNumarasi { get; set; }

        public string UrunAdi { get; set; }

        public string OdemeSekli { get; set; }

        public DateTime ETA { get; set; }

        public string TeslimatYeri { get; set; }

        public string TeslimSekli { get; set; }

        public string GirisYapanKullanici { get; set; }

        public decimal SatilabilirKisim { get; set; }

        public string TeslimYeri { get; set; }

        public string Aciklama { get; set; }

        public string OdemeDurumu { get; set; }

        public int MaliyetId { get; set; }
    }
}
