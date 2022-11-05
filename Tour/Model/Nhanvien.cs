using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Accounts = new HashSet<Account>();
            TbNhiemvus = new HashSet<TbNhiemvu>();
            TbPhutraches = new HashSet<TbPhutrach>();
        }

        public string Id { get; set; } = null!;
        public string? Mail { get; set; }
        public string? Sdt { get; set; }
        public byte[]? Picbi { get; set; }
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAvailable { get; set; }
        public int? Sldi { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<TbNhiemvu> TbNhiemvus { get; set; }
        public virtual ICollection<TbPhutrach> TbPhutraches { get; set; }
    }
}
