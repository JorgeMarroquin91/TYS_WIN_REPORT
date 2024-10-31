using System.Runtime.CompilerServices;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Queries
{
    public class ConfiguracionCarrilRepositoryQuery : IRepositoryGetAllQuery<ConfiguracionCarril>
    {
        private readonly IDbContext _dbContext;

        public ConfiguracionCarrilRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public IList<ConfiguracionCarril> GetAll()
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerConfiguracionCarrilALL";

                        using (var reader = command.ExecuteReader())
                        {
                            var configuracionCarilles = SetValueRepository<ConfiguracionCarril>.SetValueAll(reader);
                            return configuracionCarilles;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ConfiguracionCarril>();
            }
        }

        public IList<Direction> GetAllDirection()
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerDirection";

                        using (var reader = command.ExecuteReader())
                        {
                            var directions = SetValueRepository<Direction>.SetValueAll(reader);
                            return directions;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Direction>();
            }
        }

        public IList<Lane> GetAllLane()
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = _dbContext.Create().CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerLane";

                        using (var reader = command.ExecuteReader())
                        {
                            var lanes = SetValueRepository<Lane>.SetValueAll(reader);
                            return lanes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Lane>();
            }
        }

        public IList<ConfiguracionCarril> ObtenerConfiguracionCarril(long idEstacion)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerConfiguracionCarril";

                        command.AddWithValue("@idEstacion", idEstacion);

                        using (var reader = command.ExecuteReader())
                        {
                            var configuracionCarril = SetValueRepository<ConfiguracionCarril>.SetValueAll(reader);
                            return configuracionCarril;
                        }
                    }
                }
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ConfiguracionCarril>();
            }
        }
    }
}
