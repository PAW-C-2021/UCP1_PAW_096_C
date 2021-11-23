using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_096_C.Models
{
    public partial class Pemesan
    {
        public Pemesan()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPemesan { get; set; }
        public string NamaPemesan { get; set; }
        public string AlamatPemesan { get; set; }
        public string NoHpPemesan { get; set; }
        public string TotalHarga { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
