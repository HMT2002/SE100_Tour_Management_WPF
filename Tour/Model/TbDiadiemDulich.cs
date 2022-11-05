using System;
using System.Collections.Generic;

namespace Tour.Model
{
    public partial class TbDiadiemDulich
    {
        public string Id { get; set; } = null!;
        public string? Idtour { get; set; }
        public string? Iddiadiem { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Diadiem? IddiadiemNavigation { get; set; }
        public virtual Tour? IdtourNavigation { get; set; }
    }
}
