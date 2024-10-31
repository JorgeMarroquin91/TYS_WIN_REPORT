using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Dtos;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Queries
{
    public class EstacionRepositoryQuery : IRepositoryGetAllQuery<Estacion>
    {
        private readonly IDbContext _dbContext;

        public EstacionRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public IList<Estacion> GetAll()
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ObtenerEstacion";

                    using (var reader = command.ExecuteReader())
                    {
                        var estaciones = SetValueRepository<Estacion>.SetValueAll(reader);
                        return estaciones;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Estacion>();
            }
            
        }

        public Estacion GetOne<T>(T idEstacion)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ObtenerEstacionPorId";

                    command.AddWithValue("@idEstacion", idEstacion);

                    using (var reader = command.ExecuteReader())
                    {
                        var estacion = SetValueRepository<Estacion>.SetValueOne(reader);
                        return estacion;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Estacion();
            }
        }

        public Estacion GetOne(int numeroEstacion)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerEstacionPorNumero";

                        command.AddWithValue("@numeroEstacion", numeroEstacion);

                        using (var reader = command.ExecuteReader())
                        {
                            var estacion = SetValueRepository<Estacion>.SetValueOne(reader);
                            return estacion;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Estacion();
            }
        }

        public EncabezadoReportePorDia ObtenerEncabezadoReportePorDia(long idEstacion)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerEncabezadoReportePorDia";

                        command.AddWithValue("@idEstacion", idEstacion);

                        using (var reader = command.ExecuteReader())
                        {
                            var encabezadoReportePorDia = SetValueRepository<EncabezadoReportePorDia>.SetValueOne(reader);
                            return encabezadoReportePorDia;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new EncabezadoReportePorDia();
            }
        }
    }
}
