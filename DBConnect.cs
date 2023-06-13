using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace qlsvMVC
{
    internal class DBConnect
    {
        String ConnectionString = "Data Source=VNHASON;Initial Catalog=qlsv;Integrated Security=True;User ID=sa;Password=0909150405";
        private SqlConnection con;
        public static DBConnect instance;

        public static DBConnect getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnect();
            }
            return instance;
        }
        public DBConnect()
        {
            connect();
        }
        public SqlConnection getConnect
        {
            get { return con; }
            set { con = value; }
        }

        public void connect()
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                MessageBox.Show("Kết nối CSDL thành công.", "Đóng", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối CSDL không thành công.", "Đóng", MessageBoxButton.OK);
            }
        }

        public void close()
        {
            if (con.State.Equals(System.Data.ConnectionState.Open))
                con.Close();
           
        }

        
    }

}
