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
    public class CarrilRepositoryQuery : IRepositoryGetAllQuery<TipoCamino>
    {
        private readonly IDbContext _dbContext;

        public CarrilRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public IList<TipoCamino> GetAll()
        {
            using (var command = _dbContext.Create().CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ObtenerTipoCamino";

                using (var reader = command.ExecuteReader())
                {
                    var carriles = SetValueRepository<TipoCamino>.SetValueAll(reader);
                    return carriles;
                }
            }
        }
    }
}
