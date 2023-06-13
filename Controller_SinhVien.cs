using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlsvMVC
{
    internal class Controller_SinhVien
    {
        private List<SinhVien> ListSinhVien;
        private Model_SinhVien model_SinhVien;
        public Controller_SinhVien() {
            ListSinhVien = new List<SinhVien>();
            
        }

        public List<SinhVien> DSSinhVien(Lop lop)
        {
            model_SinhVien = new Model_SinhVien(lop);
            ListSinhVien = model_SinhVien.DSSinhVien(); 

            return ListSinhVien;
        }
    }
}
