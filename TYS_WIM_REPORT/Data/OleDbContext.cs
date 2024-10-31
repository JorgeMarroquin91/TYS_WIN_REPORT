using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Interfaces;

namespace TYS_WIM_REPORT.Data
{
    public class OleDbContext
    {
        private OleDbConnection? _sqlConnection;
        public OleDbContext()
        {
        }
        public OleDbConnection Create(string name, string directory)
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new OleDbConnection(ConnectionString.getOleStringConnection(name, directory));
                _sqlConnection.Open();
            }
            else
            {
                if(_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.ConnectionString = ConnectionString.getOleStringConnection(name, directory);
                    _sqlConnection.Open();
                }
            }

            return _sqlConnection;
        }
    }
}
