using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.Entities;

namespace TetraPolimerSistem.Entities.Dtos.OrderDtos
{
    public class OrderDto : IDto
    {
        public int Id { get; set; }

        public string ProformaNumara { get; set; }

        public string SiparisVerenFirma { get; set; }

        public string SiparisAlanFirma { get; set; }

        public DateTime SiparisTarihi { get; set; }

        public DateTime SevkTarihi { get; set; }

        public decimal Kur { get; set; }

        public string DovizCinsi { get; set; }

        public decimal UrunTonaj { get; set; }

        public string UrunAdi { get; set; }

        public string SevkDurumu { get; set; }

        public decimal BirimFiyat { get; set; }

        public int SevkiyatDetayId { get; set; }

        public decimal NakliyeTutar { get; set; }

        public string Aciklama { get; set; }

        public decimal KDV { get; set; }

        public decimal MaliyetTL { get; set; }

        public decimal MaliyetDoviz { get; set; }

        public decimal ToplamDovizMaliyet { get; set; }

        public decimal ToplamTLMaliyet { get; set; }

    }
}
