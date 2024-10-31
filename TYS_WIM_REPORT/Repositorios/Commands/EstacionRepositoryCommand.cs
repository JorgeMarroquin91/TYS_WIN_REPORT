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
    public class EstacionRepositoryCommand : IRepositoryCreateCommand<Estacion>, IRepositoryUpdateCommand<Estacion>, IRepositoryDeleteCommand
    {
        private readonly IDbContext _dbContext;

        public EstacionRepositoryCommand()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public decimal Create(Estacion estacion)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_CrearEstacion";

                    command.AddWithValue("@numeroEstacion", estacion.numeroEstacion);
                    command.AddWithValue("@nombreEstacion", estacion.nombreEstacion);
                    command.AddWithValue("@nombreTramoCarretera", estacion.nombreTramoCarretera);
                    command.AddWithValue("@kilometraje", estacion.kilometraje);
                    command.AddWithValue("@latitud", estacion.latitud);
                    command.AddWithValue("@longitud", estacion.longitud);
                    command.AddWithValue("@idTipoPavimento", estacion.idTipoPavimento);
                    command.AddWithValue("@idTipoCamino", estacion.idTipoCamino);
                    command.AddWithValue("@idTipovia", estacion.idTipovia);
                    command.AddWithValue("@idEmpresa", estacion.idEmpresa);

                    var response = command.ExecuteScalar();

                    return (decimal)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int Delete<T>(T idEstacion)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_EliminarEstacion";

                    command.AddWithValue("@idEstacion", idEstacion);

                    var response = command.ExecuteNonQuery();

                    return (int)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int Update(Estacion estacion)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ActualizarEstacion";

                    command.AddWithValue("@idEstacion", estacion.idEstacion);
                    command.AddWithValue("@numeroEstacion", estacion.numeroEstacion);
                    command.AddWithValue("@nombreEstacion", estacion.nombreEstacion);
                    command.AddWithValue("@nombreTramoCarretera", estacion.nombreTramoCarretera);
                    command.AddWithValue("@kilometraje", estacion.kilometraje);
                    command.AddWithValue("@latitud", estacion.latitud);
                    command.AddWithValue("@longitud", estacion.longitud);
                    command.AddWithValue("@idTipoPavimento", estacion.idTipoPavimento);
                    command.AddWithValue("@idTipoCamino", estacion.idTipoCamino);
                    command.AddWithValue("@idTipovia", estacion.idTipovia);
                    command.AddWithValue("@idEmpresa", estacion.idEmpresa);

                    var response = command.ExecuteNonQuery();

                    return (int)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


    }
}
