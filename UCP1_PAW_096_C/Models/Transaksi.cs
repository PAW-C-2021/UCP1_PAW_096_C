using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_096_C.Models
{
    public partial class Transaksi
    {
        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public string HargaBarang { get; set; }
        public string JumlahBarang { get; set; }
        public int? IdPemesan { get; set; }
        public int? IdOjek { get; set; }
        public int? IdPemilikToko { get; set; }
        public string TotalHarga { get; set; }

        public virtual Ojek IdOjekNavigation { get; set; }
        public virtual Pemesan IdPemesanNavigation { get; set; }
        public virtual PemilikToko IdPemilikTokoNavigation { get; set; }
    }
}
