using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class TbPhuongtien
    {
        public string Id { get; set; } = null!;
        public string? Iddoan { get; set; }
        public string? Idphuongtien { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Doan? IddoanNavigation { get; set; }
        public virtual Phuongtien? IdphuongtienNavigation { get; set; }
    }
}
