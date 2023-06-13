using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlsvMVC
{
    internal class SinhVien
    {
        private String _MaSV;
        private String _HoTen;
        private String _MaLop;

        public String MaSV
        {
            get { return _MaSV; }
            set { _MaSV = value; }
        }
        public String HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        public string MaLop
        {
            get { return _MaLop; }
            set { _MaLop = value; }
        }
    }
}
