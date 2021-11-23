using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_096_C.Models
{
    public partial class JenisKendaraan
    {
        public JenisKendaraan()
        {
            Ojeks = new HashSet<Ojek>();
        }

        public int IdJenisKendaraan { get; set; }
        public string JenisKendaraan1 { get; set; }

        public virtual ICollection<Ojek> Ojeks { get; set; }
    }
}
