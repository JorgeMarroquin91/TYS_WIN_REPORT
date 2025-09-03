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
    public class LicenciaRepositoryQuery
    {
        private readonly IDbContext _dbContext;

        public LicenciaRepositoryQuery()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }

        public Licencia GetAll()
        {
            Licencia licencia = new Licencia();
            int contador = 0;
            var aes = new Aes256Encryption();

            try
            {
                using (var command = _dbContext.Create().CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ObtenerLicencia";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (contador == 0)
                            {
                                licencia.dia = aes.Decrypt(reader.GetString(0));
                            }
                            if (contador == 1)
                            {
                                licencia.mes = aes.Decrypt(reader.GetString(0));
                            }
                            if (contador == 2)
                            {
                                licencia.anio = aes.Decrypt(reader.GetString(0));
                            }
                            contador++;
                        }
                        return licencia;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return licencia;
            }
        }
    }
}