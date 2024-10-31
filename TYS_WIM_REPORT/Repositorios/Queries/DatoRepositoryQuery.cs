using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Queries
{
    internal class DatoRepositoryQuery
    {
        private readonly IDbContext _dbContext;

        public DatoRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public IList<TablaDatosDto> GetAll(int site_number, DateTime date, String nombreTabla)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerDato";

                        command.AddWithValue("@SITE_NUMBER", site_number);
                        command.AddWithValue("@DATE", date);
                        command.AddWithValue("@nombreTabla", nombreTabla);

                        var reader = command.ExecuteReader();

                        var datos = SetValueRepository<TablaDatosDto>.SetValueAll(reader);
                        return datos;
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<TablaDatosDto>();
            }            
        }
    }
}
