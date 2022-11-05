using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Diadiem
    {
        public Diadiem()
        {
            TbDiadiemDuliches = new HashSet<TbDiadiemDulich>();
        }

        public string Id { get; set; } = null!;
        public string? Ten { get; set; }
        public string? Idtinh { get; set; }
        public string? Chitiet { get; set; }
        public byte[]? Picbi { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? Gia { get; set; }

        public virtual Tinh? IdtinhNavigation { get; set; }
        public virtual ICollection<TbDiadiemDulich> TbDiadiemDuliches { get; set; }
    }
}
