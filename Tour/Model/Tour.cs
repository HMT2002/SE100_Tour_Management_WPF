using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Tour
    {
        public Tour()
        {
            Doans = new HashSet<Doan>();
            TbDiadiemDuliches = new HashSet<TbDiadiemDulich>();
        }

        public string Id { get; set; } = null!;
        public string? Ten { get; set; }
        public string? Dacdiem { get; set; }
        public string? Loai { get; set; }
        public decimal? Gia { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Doan> Doans { get; set; }
        public virtual ICollection<TbDiadiemDulich> TbDiadiemDuliches { get; set; }
    }
}
