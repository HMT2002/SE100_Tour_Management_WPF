using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Ve
    {
        public string Id { get; set; } = null!;
        public DateTime? Ngaymua { get; set; }
        public decimal? Gia { get; set; }
        public string? Idkhach { get; set; }
        public string? Iddoan { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Doan? IddoanNavigation { get; set; }
        public virtual Khachhang? IdkhachNavigation { get; set; }
    }
}
