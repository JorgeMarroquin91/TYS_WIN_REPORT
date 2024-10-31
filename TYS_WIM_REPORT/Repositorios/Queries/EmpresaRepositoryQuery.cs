using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Queries
{
    public class EmpresaRepositoryQuery : IRepositoryGetOneQuery<Empresa>, IRepositoryGetAllQuery<Empresa>
    {
        private readonly IDbContext _dbContext;

        public EmpresaRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }
        public IList<Empresa> GetAll()
        {
            using (var connection = _dbContext.Create())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ObtenerEmpresa";

                    using (var reader = command.ExecuteReader())
                    {
                        var empresas = SetValueRepository<Empresa>.SetValueAll(reader);
                        return empresas;
                    }
                }
            }
        }

        public Empresa GetOne<T>(T idEmpresa)
        {
            using (var command = _dbContext.Create().CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ObtenerEmpresaPorId";

                command.AddWithValue("@idEmpresa", idEmpresa);

                using (var reader = command.ExecuteReader())
                {
                    var Empresa = SetValueRepository<Empresa>.SetValueOne(reader);
                    return Empresa;
                }
            }
        }

        public Empresa GetEmpresaActiva()
        {
            using (var connection = _dbContext.Create())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_EmpresaActiva";

                    using (var reader = command.ExecuteReader())
                    {
                        var Empresa = SetValueRepository<Empresa>.SetValueOne(reader);
                        return Empresa;
                    }
                }
            }
        }
    }
}
