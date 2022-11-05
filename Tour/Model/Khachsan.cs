using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Khachsan
    {
        public Khachsan()
        {
            TbKhachsans = new HashSet<TbKhachsan>();
        }

        public string Id { get; set; } = null!;
        public string? Diachi { get; set; }
        public string? Sdt { get; set; }
        public byte[]? Picbi { get; set; }
        public string? Chitiet { get; set; }
        public decimal? Gia { get; set; }
        public string? Idtinh { get; set; }
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Tinh? IdtinhNavigation { get; set; }
        public virtual ICollection<TbKhachsan> TbKhachsans { get; set; }
    }
}
