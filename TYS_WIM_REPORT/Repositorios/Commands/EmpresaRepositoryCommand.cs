using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Repositorios.Commands
{
    internal class EmpresaRepositoryCommand : IRepositoryCreateCommand<Empresa>, IRepositoryUpdateCommand<Empresa>, IRepositoryDeleteCommand
    {
        private readonly IDbContext _dbContext;

        public EmpresaRepositoryCommand()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }
        public decimal Create(Empresa empresa)
        {
            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_CrearEmpresa";

                    command.AddWithValue("@nombreEmpresa", empresa.nombreEmpresa);
                    command.AddWithValue("@logotipo", empresa.logotipo);

                    var response = command.ExecuteScalar();

                    return (decimal)response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int Delete<T>(T idEmpresa)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_EliminarEmpresa";

                        command.AddWithValue("@idEmpresa", idEmpresa);

                        var response = command.ExecuteNonQuery();

                        return (int)response;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int Update(Empresa empresa)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ActualizarEmpresa";

                        command.AddWithValue("@idEmpresa", empresa.idEmpresa);
                        command.AddWithValue("@nombreEmpresa", empresa.nombreEmpresa);
                        command.AddWithValue("@logotipo", empresa.logotipo);

                        var response = command.ExecuteNonQuery();

                        return (int)response;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int Activar(long idEmpresa)
        {
            try
            {
                using (var connection = _dbContext.Create())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_ActivarEmpresa";

                        command.AddWithValue("@idEmpresa", idEmpresa);

                        var response = command.ExecuteNonQuery();

                        return (int)response;
                    }
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
