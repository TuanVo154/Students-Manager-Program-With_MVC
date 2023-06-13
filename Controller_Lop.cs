using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlsvMVC
{
    internal class Controller_Lop
    {
        private List<Lop> listlop;
        private Model_Lop lop;

        public Controller_Lop()
        {
            listlop = new List<Lop>();
            lop= new Model_Lop();
        }

        public List<Lop> getDSLop()
        {
            listlop = lop.DSLop();
            return listlop;
        }

        public void ThemLop(Lop l)
        {
            lop.ThemLop(l);
        }

    }
}
