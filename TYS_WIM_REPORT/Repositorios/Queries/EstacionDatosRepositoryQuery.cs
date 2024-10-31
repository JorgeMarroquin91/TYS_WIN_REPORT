using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Dtos;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Queries
{
    public class EstacionDatosRepositoryQuery
    {
        private readonly IDbContext _dbContext;

        public EstacionDatosRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public EstacionDatos GetOne(string tabla, long? idEstacion)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerEstacionDatosPorParametros";

                        command.AddWithValue("@tabla", tabla);
                        command.AddWithValue("@idEstacion", idEstacion);

                        using (var reader = command.ExecuteReader())
                        {
                            var estacion = SetValueRepository<EstacionDatos>.SetValueOne(reader);
                            return estacion;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new EstacionDatos();
            }
        }

        public Boolean ExistsTable(string tabla)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ExisteEstacionAnio";

                        command.AddWithValue("@tabla", tabla);

                        var result = command.ExecuteScalar();

                        if ((int)result == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<DatosTpda> GetAllTPDA(string tabla)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_CalcularTPDA";

                        command.AddWithValue("@estacion", tabla);

                        using (var reader = command.ExecuteReader())
                        {
                            var datosTpda = SetValueRepository<DatosTpda>.SetValueAll(reader);
                            return datosTpda;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<DatosTpda>();
            }
        }

        public IList<EstacionDatos> GetAll(int anio)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ObtenerEstacionDatosLike";

                        command.AddWithValue("@anio", anio);

                        using (var reader = command.ExecuteReader())
                        {
                            var estaciones = SetValueRepository<EstacionDatos>.SetValueAll(reader);
                            return estaciones;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<EstacionDatos>();
            }
        }
    }
}
