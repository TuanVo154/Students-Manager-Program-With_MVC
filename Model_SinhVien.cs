using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace qlsvMVC
{
    internal class Model_SinhVien : Model
    {
        private List<SinhVien> ListSinhVien;
        private SqlDataAdapter sdaSinhVien;
        private DataSet dsSinhVien;
        private DataTable dtSinhVien;

        public Model_SinhVien(Lop lop) {
            ListSinhVien = new List<SinhVien>();
            sdaSinhVien = new SqlDataAdapter();
            dsSinhVien = new DataSet();
            dtSinhVien = new DataTable();

            String sel_sql = "SELECT * FROM SinhVien WHERE Malop=@ml;";
            SqlCommand sel_cmd = new SqlCommand(sel_sql, db.getConnect);
            SqlParameter malop = new SqlParameter();
            malop.ParameterName = "@ml";
            malop.SqlDbType = SqlDbType.NVarChar;
            malop.Value = lop.MaLop;
            sel_cmd.Parameters.Add(malop);
            sdaSinhVien.SelectCommand = sel_cmd;

            String ins_sql = "INSERT INTO SinhVien(MaSV, HoTen, MaLop) VALUES(@msv, @ht, @ml);";
            SqlCommand ins_cmd = new SqlCommand(ins_sql, db.getConnect);
            SqlParameter masv = new SqlParameter();
            masv.ParameterName = "@msv";
            masv.SqlDbType = SqlDbType.NVarChar;
            masv.SourceColumn = "MaSV";
            SqlParameter hoten = new SqlParameter();
            hoten.ParameterName = "@ht";
            hoten.SqlDbType = SqlDbType.NVarChar;
            hoten.SourceColumn = "HoTen";
            SqlParameter malop1 = new SqlParameter();
            malop1.ParameterName = "@ml";
            malop1.SqlDbType = SqlDbType.NVarChar;
            malop1.SourceColumn = "MaLop";
            ins_cmd.Parameters.Add(masv);
            ins_cmd.Parameters.Add(hoten);
            ins_cmd.Parameters.Add(malop1);
            sdaSinhVien.InsertCommand = ins_cmd;

            dsSinhVien = new DataSet();
            sdaSinhVien.Fill(dsSinhVien);
            dtSinhVien = dsSinhVien.Tables[0];
        }

        public List<SinhVien> DSSinhVien()
        {
            foreach (DataRow r in dtSinhVien.Rows)
            {
                SinhVien s = new SinhVien();
                s.MaSV = r["MaSV"].ToString();
                s.HoTen = r["HoTen"].ToString();
                s.MaLop = r["MaLop"].ToString();
                ListSinhVien.Add(s);
            }
            return ListSinhVien;
        }

    }
}
