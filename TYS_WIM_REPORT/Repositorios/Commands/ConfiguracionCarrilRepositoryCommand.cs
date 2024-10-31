using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Commands
{
    public class ConfiguracionCarrilRepositoryCommand : IRepositoryCreateCommand<ConfiguracionCarril>, IRepositoryUpdateCommand<ConfiguracionCarril>, IRepositoryDeleteCommand
    {
        private readonly IDbContext _dbContext;

        public ConfiguracionCarrilRepositoryCommand()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public decimal Create(ConfiguracionCarril configuracionCarril)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_CrearConfiguracionCarril";

                        command.AddWithValue("@DIRECTION_NUMBER", configuracionCarril.DIRECTION_NUMBER);
                        command.AddWithValue("@DIRECTION_NAME", configuracionCarril.DIRECTION_NAME);
                        command.AddWithValue("@LANE", configuracionCarril.LANE);
                        command.AddWithValue("@LANE_NAME", configuracionCarril.LANE_NAME);
                        command.AddWithValue("@idEstacion", configuracionCarril.idEstacion);

                        var response = command.ExecuteScalar();

                        return (decimal)response;
                    }
                }
            }
            catch (Exception ex) 
            {
                return 0;
            }

        }

        public int Update(ConfiguracionCarril configuracionCarril)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ActualizarConfiguracionCarril";

                        command.AddWithValue("@idConfiguracionCarril", configuracionCarril.idConfiguracionCarril);
                        command.AddWithValue("@DIRECTION_NUMBER", configuracionCarril.DIRECTION_NUMBER);
                        command.AddWithValue("@DIRECTION_NAME", configuracionCarril.DIRECTION_NAME);
                        command.AddWithValue("@LANE", configuracionCarril.LANE);
                        command.AddWithValue("@LANE_NAME", configuracionCarril.LANE_NAME);
                        command.AddWithValue("@idEstacion", configuracionCarril.idEstacion);

                        var response = command.ExecuteNonQuery();

                        return (int)response;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete<T>(T idConfiguracionCarril)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_EliminarConfiguracionCarril";

                    command.AddWithValue("@idConfiguracionCarril", idConfiguracionCarril);

                    var response = command.ExecuteNonQuery();

                    return (int)response;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
