using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Data
{
    public static class DbCommandExtensions
    {
        public static void AddWithValue(this IDbCommand command, string nameParameter, object value)
        {
            IDbDataParameter dbDataParameter = command.CreateParameter();
            dbDataParameter.ParameterName = nameParameter;
            dbDataParameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(dbDataParameter);
        }
    }
}
