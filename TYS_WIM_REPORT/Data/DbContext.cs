using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Interfaces;

namespace TYS_WIM_REPORT.Data
{
    public sealed class DbContext : IDbContext, IDisposable
    {
        private SqlConnection? _sqlConnection;
        private string _stringConnection;
        private static DbContext? _instance;
        private DbContext(string stringConnection) 
        {
            _stringConnection = stringConnection;
        }

        public static DbContext GetDbContext(string stringConnection)
        {
            if (_instance == null)
            {
                _instance = new DbContext(stringConnection);
            }
            return _instance;
        }
        public SqlConnection Create()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(_stringConnection);
                _sqlConnection.Open();
            }
            else
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.ConnectionString = _stringConnection;
                    _sqlConnection.Open();
                }
            }
            
            return _sqlConnection;
        }

        public void Dispose()
        {
            _instance?.Dispose();
            _instance = null;
        }
    }
}
