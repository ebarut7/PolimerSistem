﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Core.Entities;

namespace TetraPolimerSistem.Entities.Dtos.SevkiyatDetayDtos
{
    public class SevkiyatDetayDto : IDto
    {
        public int Id { get; set; }
        public string Sofor { get; set; }

        public string Plaka { get; set; }

        public int TCKN { get; set; }

        public string TelefonNumara { get; set; }

        public string Firma { get; set; }

        public string Aciklama { get; set; }
    }
}
