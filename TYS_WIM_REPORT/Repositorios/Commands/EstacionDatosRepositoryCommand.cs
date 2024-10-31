using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Commands
{
    public class EstacionDatosRepositoryCommand
    {
        private readonly IDbContext _dbContext;

        public EstacionDatosRepositoryCommand()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public void Create(EstacionDatos estacionDatos)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_CrearTabla";

                        command.AddWithValue("@nombreTabla", estacionDatos.tabla);
                        command.AddWithValue("@idEstacion", estacionDatos.idEstacion);

                        command.ExecuteNonQuery();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
