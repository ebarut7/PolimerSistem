namespace TetraPolimerSistem.WEBUI.Models.ViewModels
{
    public class DisTicaretMaliyetVM
    {
        public int Id { get; set; }

        public int DisTicaretId { get; set; }

        public decimal Kur { get; set; }

        public decimal BirimFiyat { get; set; }

        public decimal UrunTonaj { get; set; }

        public decimal GumrukOran { get; set; }

        public decimal GumrukVergisi { get; set; }

        public decimal DamgaVergisi { get; set; }

        public decimal LokalMasraf { get; set; }

        public decimal LimanMasraf { get; set; }

        public decimal OrdinoBedel { get; set; }

        public decimal GumrukKomisyon { get; set; }

        public decimal Nakliye { get; set; }

        public decimal Demuraj { get; set; }

        public decimal Diger { get; set; }

        public decimal UrunBedelDoviz { get; set; }

        public decimal UrunBedelTL { get; set; }

        public decimal TLMasraf { get; set; }

        public decimal DovizMasraf { get; set; }

        public decimal ToplamTLMaliyet { get; set; }

        public decimal ToplamDovizMaliyet { get; set; }

        public decimal MaliyetliBirimFiyat { get; set; }

        public decimal KarliBirimFiyat { get; set; }
    }
}
