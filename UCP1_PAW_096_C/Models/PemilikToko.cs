using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_096_C.Models
{
    public partial class PemilikToko
    {
        public PemilikToko()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdPemilikToko { get; set; }
        public string NamaPemilikToko { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
