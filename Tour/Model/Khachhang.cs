using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Ves = new HashSet<Ve>();
        }

        public string Id { get; set; } = null!;
        public string? Tenkh { get; set; }
        public string? Cmnd { get; set; }
        public string? Diachi { get; set; }
        public string? Gioitinh { get; set; }
        public string? Sdt { get; set; }
        public byte[]? Picbi { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Ve> Ves { get; set; }
    }
}
