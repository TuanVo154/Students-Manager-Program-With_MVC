using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlsvMVC
{
    internal class Lop
    {
        private String _MaLop;
        private String _TenLop;
        private int _SiSo;

        public String MaLop
        {
            get { return _MaLop; }
            set { _MaLop = value; }
        }
        public String TenLop
        {
            get { return _TenLop; }
            set { _TenLop = value; }
        }
        public int SiSo
        {
            get { return _SiSo; }
            set { _SiSo = value; }
        }
    }
}
