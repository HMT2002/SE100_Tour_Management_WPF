using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Doan
    {
        public Doan()
        {
            TbKhachsans = new HashSet<TbKhachsan>();
            TbNhiemvus = new HashSet<TbNhiemvu>();
            TbPhuongtiens = new HashSet<TbPhuongtien>();
            TbPhutraches = new HashSet<TbPhutrach>();
            Ves = new HashSet<Ve>();
        }

        public string Id { get; set; } = null!;
        public string? Ten { get; set; }
        public DateTime? Ngaykhoihanh { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public string? Chitietchuongtrinh { get; set; }
        public string? Idchiphi { get; set; }
        public string? Idtour { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Chiphi? IdchiphiNavigation { get; set; }
        public virtual Tour? IdtourNavigation { get; set; }
        public virtual ICollection<TbKhachsan> TbKhachsans { get; set; }
        public virtual ICollection<TbNhiemvu> TbNhiemvus { get; set; }
        public virtual ICollection<TbPhuongtien> TbPhuongtiens { get; set; }
        public virtual ICollection<TbPhutrach> TbPhutraches { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
