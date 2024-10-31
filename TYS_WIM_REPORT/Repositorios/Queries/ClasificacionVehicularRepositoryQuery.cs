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
    public class ClasificacionVehicularRepositoryQuery : IRepositoryGetOneQuery<ClasificacionVehicular>, IRepositoryGetAllQuery<ClasificacionVehicular>
    {
        private readonly IDbContext _dbContext;

        public ClasificacionVehicularRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }
        public IList<ClasificacionVehicular> GetAll()
        {
            using (var command = _dbContext.Create().CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ObtenerClasificacionVehicular";

                using (var reader = command.ExecuteReader())
                {
                    var clasificacionVehicular = SetValueRepository<ClasificacionVehicular>.SetValueAll(reader);
                    return clasificacionVehicular;
                }
            }
        }

        public ClasificacionVehicular GetOne<T>(T idClasificacionVehicular)
        {
            using (var command = _dbContext.Create().CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ObtenerClasificacionVehicularPorId";

                command.AddWithValue("@idClasificacionVehicular", idClasificacionVehicular);

                using (var reader = command.ExecuteReader())
                {
                    var clasificacionVehicular = SetValueRepository<ClasificacionVehicular>.SetValueOne(reader);
                    return clasificacionVehicular;
                }
            }
        }
    }
}
