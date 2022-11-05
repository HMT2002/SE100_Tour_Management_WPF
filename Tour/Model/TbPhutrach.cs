using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class TbPhutrach
    {
        public string Id { get; set; } = null!;
        public string? Iddoan { get; set; }
        public string? Idnhanvien { get; set; }
        public string? Phutrach { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Doan? IddoanNavigation { get; set; }
        public virtual Nhanvien? IdnhanvienNavigation { get; set; }
    }
}
