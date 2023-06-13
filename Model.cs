using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace qlsvMVC
{
    internal class Model
    {
        protected DBConnect db;
        public Model() {
            db = DBConnect.getInstance();

            //db = new DBConnect();
            //db.connect();
        }
    }
    
}
