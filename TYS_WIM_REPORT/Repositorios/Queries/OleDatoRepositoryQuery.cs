using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Queries
{
    public class OleDatoRepositoryQuery
    {
        private readonly OleDbContext? _oleDbContext;

        public OleDatoRepositoryQuery()
        {
            _oleDbContext = new OleDbContext();
        }

        public IList<OleDato> GetAll(string name, string directory)
        {
            using (var connection = _oleDbContext.Create(name, directory))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM VBV";

                    using (var reader = command.ExecuteReader())
                    {
                        var datos = SetValueRepository<OleDato>.SetValueAll(reader);
                        return datos;
                    }
                }
            }
            
        }
    }
}
