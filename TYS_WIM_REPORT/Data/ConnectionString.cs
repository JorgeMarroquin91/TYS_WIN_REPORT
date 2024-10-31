using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Properties;

namespace TYS_WIM_REPORT.Data
{
    public static class ConnectionString
    {
        public static string getStringConnection()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = Settings.Default.SERVIDOR;
            stringBuilder.InitialCatalog = Settings.Default.BASE;
            stringBuilder.IntegratedSecurity = Settings.Default.SECURITY;
            stringBuilder.TrustServerCertificate = true;
            stringBuilder.UserID = Settings.Default.USUARIO;
            stringBuilder.Password = Settings.Default.PASSWORD;

            return stringBuilder.ConnectionString;
        }

        public static string getOleStringConnection(string name, string directory)
        {
            OleDbConnectionStringBuilder oleStringBuilder = new();

            oleStringBuilder.Provider = "Microsoft.ACE.OLEDB.16.0";
            oleStringBuilder.DataSource = Settings.Default.directorioOrigen + "\\" + directory + "\\" + name;
            oleStringBuilder.PersistSecurityInfo = false;

            return oleStringBuilder.ConnectionString;
        }
    }
}
