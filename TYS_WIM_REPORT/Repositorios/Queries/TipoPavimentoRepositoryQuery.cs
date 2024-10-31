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
    public class TipoPavimentoRepositoryQuery : IRepositoryGetAllQuery<TipoPavimento>
    {
        private readonly IDbContext _dbContext;

        public TipoPavimentoRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public IList<TipoPavimento> GetAll()
        {
            using (var command = _dbContext.Create().CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ObtenerTipoPavimento";

                using (var reader = command.ExecuteReader())
                {
                    var tipoPavimentos = SetValueRepository<TipoPavimento>.SetValueAll(reader);
                    return tipoPavimentos;
                }
            }
        }
    }
}
