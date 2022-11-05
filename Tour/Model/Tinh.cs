using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Tinh
    {
        public Tinh()
        {
            Diadiems = new HashSet<Diadiem>();
            Khachsans = new HashSet<Khachsan>();
            Phuongtiens = new HashSet<Phuongtien>();
        }

        public string Id { get; set; } = null!;
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Diadiem> Diadiems { get; set; }
        public virtual ICollection<Khachsan> Khachsans { get; set; }
        public virtual ICollection<Phuongtien> Phuongtiens { get; set; }
    }
}
