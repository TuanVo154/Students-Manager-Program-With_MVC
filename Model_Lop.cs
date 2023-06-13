using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlsvMVC
{
    internal class Model_Lop : Model
    {
        private List<Lop> ListLop;
        private SqlDataAdapter sdaLop;
        private DataSet dsLop;
        private DataTable dtLop;
        public Model_Lop() {
            ListLop = new List<Lop>();
            sdaLop = new SqlDataAdapter();
            dsLop = new DataSet();
            dtLop = new DataTable();

            String sel_sql = "SELECT * FROM Lop;";
            SqlCommand sel_cmd = new SqlCommand(sel_sql, db.getConnect);
            sdaLop.SelectCommand = sel_cmd;

            String upd_sql = "UPDATE Lop SET TenLop=@tl, SiSo=@ss WHERE MaLop=@ml;";
            SqlCommand upd_cmd = new SqlCommand(upd_sql, db.getConnect);
            SqlParameter tenlop = new SqlParameter();
            tenlop.ParameterName = "@tl";
            tenlop.SqlDbType = SqlDbType.NVarChar;
            tenlop.SourceColumn = "TenLop";
            SqlParameter siso = new SqlParameter();
            siso.ParameterName = "@ss";
            siso.SqlDbType = SqlDbType.Int;
            siso.SourceColumn = "SiSo";
            SqlParameter malop = new SqlParameter();
            malop.ParameterName = "@ml";
            malop.SqlDbType = SqlDbType.NVarChar;
            malop.SourceColumn = "MaLop";
            upd_cmd.Parameters.Add(tenlop);
            upd_cmd.Parameters.Add(siso);
            upd_cmd.Parameters.Add(malop);
            sdaLop.UpdateCommand = upd_cmd;

            String ins_sql = "INSERT INTO Lop(MaLop, TenLop, SiSo) VALUES(@ml, @tl, 0);";
            SqlParameter malop1 = new SqlParameter();
            malop1.ParameterName = "@ml";
            malop1.SqlDbType = SqlDbType.NVarChar;
            malop1.SourceColumn = "MaLop";
            SqlParameter tenlop1 = new SqlParameter();
            tenlop1.ParameterName = "@tl";
            tenlop1.SqlDbType = SqlDbType.NVarChar;
            tenlop1.SourceColumn = "TenLop";
            SqlCommand ins_cmd = new SqlCommand(ins_sql, db.getConnect);
            ins_cmd.Parameters.Add(malop1);
            ins_cmd.Parameters.Add(tenlop1);
            sdaLop.InsertCommand = ins_cmd;

            sdaLop.Fill(dsLop);
            dtLop = dsLop.Tables[0];
        }  

        public List<Lop> DSLop()
        {
            foreach (DataRow r in dtLop.Rows)
            {
                Lop l = new Lop();
                l.MaLop = r["MaLop"].ToString();
                l.TenLop = r["TenLop"].ToString();
                l.SiSo = int.Parse(r["SiSo"].ToString());
                ListLop.Add(l);
            }
            return ListLop;
        }

        public void ThemLop(Lop lop)
        {
            DataRow r = dtLop.NewRow();
            r["MaLop"] = lop.MaLop;
            r["TenLop"] = lop.TenLop;
            r["SiSo"] = 0;
            dtLop.Rows.Add(r);

            sdaLop.Update(dsLop);
        }

    }
}
