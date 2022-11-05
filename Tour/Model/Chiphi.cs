using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class Chiphi
    {
        public Chiphi()
        {
            Doans = new HashSet<Doan>();
        }

        public string Id { get; set; } = null!;
        public decimal? Phian { get; set; }
        public decimal? Phichoi { get; set; }
        public decimal? Phikhac { get; set; }
        public decimal? Tong { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Doan> Doans { get; set; }
    }
}
