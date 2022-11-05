using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Account
    {
        public string Id { get; set; } = null!;
        public string? Acc { get; set; }
        public string? Pass { get; set; }
        public string? Idnhanvien { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Nhanvien? IdnhanvienNavigation { get; set; }
    }
}
