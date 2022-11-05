using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Phuongtien
    {
        public Phuongtien()
        {
            TbPhuongtiens = new HashSet<TbPhuongtien>();
        }

        public string Id { get; set; } = null!;
        public string? Ten { get; set; }
        public byte[]? Picbi { get; set; }
        public string? Loai { get; set; }
        public string? Idtinh { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? Gia { get; set; }

        public virtual Tinh? IdtinhNavigation { get; set; }
        public virtual ICollection<TbPhuongtien> TbPhuongtiens { get; set; }
    }
}
