using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_096_C.Models
{
    public partial class Ojek
    {
        public Ojek()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdOjek { get; set; }
        public string NamaOjek { get; set; }
        public string PlatNomor { get; set; }
        public int? IdJenisKendaraan { get; set; }

        public virtual JenisKendaraan IdJenisKendaraanNavigation { get; set; }
        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
