using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;

        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set => _ins = value; }

        public QL_TOUR_DU_LICHContext DB { get => db; set => db = value; }

        private QL_TOUR_DU_LICHContext db;

        public DataProvider()
        {
            DB = new QL_TOUR_DU_LICHContext();

        }
    }
}
