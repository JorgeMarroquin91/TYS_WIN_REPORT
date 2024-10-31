using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Commands
{
    public class ClasificacionVehicularRepositoryCommand : IRepositoryCreateCommand<ClasificacionVehicular>, IRepositoryUpdateCommand<ClasificacionVehicular>, IRepositoryDeleteCommand
    {
        private readonly IDbContext _dbContext;

        public ClasificacionVehicularRepositoryCommand()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }
        public decimal Create(ClasificacionVehicular clasificacionVehicular)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_GuardarClasificacionVehicular";

                    command.AddWithValue("@clasificacion", clasificacionVehicular.clasificacion);
                    command.AddWithValue("@pesoMaximo", clasificacionVehicular.pesoMaximo);
                    //command.AddWithValue("@pesoMaximoEje", clasificacionVehicular.pesoMaximoEje);
                    command.AddWithValue("@idEmpresa", clasificacionVehicular.idEmpresa);

                    var response = command.ExecuteScalar();

                    return (Decimal)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            
        }

        public int Delete<T>(T idClasificacionVehicular)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_EliminarClasificacionVehicular";

                    command.AddWithValue("@idClasificacionVehicular", idClasificacionVehicular);

                    var response = command.ExecuteNonQuery();

                    return (int)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            
        }

        public int Update(ClasificacionVehicular clasificacionVehicular)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ActualizarClasificacionVehicular";

                    command.AddWithValue("@idClasificacionVehicular", clasificacionVehicular.idClasificacionVehicular);
                    command.AddWithValue("@clasificacion", clasificacionVehicular.clasificacion);
                    command.AddWithValue("@pesoMaximo", clasificacionVehicular.pesoMaximo);
                    //command.AddWithValue("@pesoMaximoEje", clasificacionVehicular.pesoMaximoEje);
                    command.AddWithValue("@idEmpresa", clasificacionVehicular.idEmpresa);

                    var response = command.ExecuteNonQuery();

                    return (int)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            
        }
    }
}
