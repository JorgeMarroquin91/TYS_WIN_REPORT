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
    public class TipoViaRepositoryQuery : IRepositoryGetAllQuery<TipoVia>
    {
        private readonly IDbContext _dbContext;

        public TipoViaRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public IList<TipoVia> GetAll()
        {
            using (var command = _dbContext.Create().CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ObtenerTipoVia";

                using (var reader = command.ExecuteReader())
                {
                    var tipoVias = SetValueRepository<TipoVia>.SetValueAll(reader);
                    return tipoVias;
                }
            }
        }
    }
}
