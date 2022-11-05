using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class TbKhachsan
    {
        public string Id { get; set; } = null!;
        public string? Iddoan { get; set; }
        public string? Idkhachsan { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Doan? IddoanNavigation { get; set; }
        public virtual Khachsan? IdkhachsanNavigation { get; set; }
    }
}
