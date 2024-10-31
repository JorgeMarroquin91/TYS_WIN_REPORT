using Microsoft.Data.SqlClient;
using System.Data;
using TYS_WIM_REPORT.Data;
using TYS_WIM_REPORT.Interfaces;
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT.Repositorios.Commands
{
    public class DatoRepositoryCommand
    {
        private readonly IDbContext _dbContext;
        private readonly DatoRepositoryQuery _datoRepositoryQuery = new();
        List<TablaDatosDto> tablaDatosDtos;

        public DatoRepositoryCommand()
        {
            _dbContext = DbContext.GetDbContext(ConnectionString.getStringConnection());
        }
        //public void Create(IList<OleDato> oleDatos, StreamWriter writer, string archivo, string carpeta, TextBox txtLoadDatos)
        //{
        //    List<decimal> ids = new List<decimal>();
        //    SqlTransaction? transaction = null;

        //    try
        //    {
        //        using (var connection = _dbContext.Create())
        //        {
        //            using (var command = connection.CreateCommand())
        //            {
        //                transaction = connection.BeginTransaction();
        //                command.CommandType = System.Data.CommandType.StoredProcedure;
        //                command.CommandText = "SP_CrearDato";
        //                command.Transaction = transaction;

        //                //variable de conteo
        //                var contador = 1;
        //                var totalDatos = oleDatos.Count;

        //                foreach (var dato in oleDatos)
        //                {
        //                    var datoReponse = _datoRepositoryQuery.GetOne((int)dato.SITE_NUMBER, (int)dato.SERIAL_NUMBER, (DateTime)dato.DATE);

        //                    if (datoReponse == 1)
        //                    {
        //                        writer.WriteLine("Archivo ya cargado: " + archivo);
        //                        break;
        //                    }

        //                    command.Parameters.Clear();

        //                    foreach (var property in typeof(OleDato).GetProperties())
        //                    {
        //                        command.AddWithValue(property.Name, property.GetValue(dato));
        //                    }

        //                    var createResponse = command.ExecuteScalar();

        //                    if ((decimal)createResponse > 0)
        //                    {
        //                        txtLoadDatos.Clear();
        //                        txtLoadDatos.AppendText("Estación: " + carpeta + " \nArchivo: " + archivo + " \nRegistro " + contador + " de " + totalDatos + "\n");
        //                        txtLoadDatos.Refresh();
        //                        contador++;
        //                        ids.Add((decimal)createResponse);
        //                    }
        //                }

        //                transaction.Commit();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        if (transaction is not null)
        //        {
        //            writer.WriteLine("Archivo: " + archivo + " - Fallo al cargar");
        //            transaction.Rollback();
        //        }
        //    }
        //    finally
        //    {
        //        if (transaction is not null)
        //        {
        //            transaction.Dispose();
        //        }
        //    }
        //}

        public int CreateBulk(IList<OleDato> oleDatos, StreamWriter writer, string archivo, string tabla)
        {
            try
            {
                //Creamos la tabla igual que en sql server
                var tableDato = new DataTable();
                
                //Llenamos las columnas de la tabla
                foreach (var property in typeof(Dato).GetProperties())
                {
                    tableDato.Columns.Add(property.Name);

                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        tableDato.Columns[property.Name].DataType = Nullable.GetUnderlyingType(property.PropertyType);
                    }
                    else
                    {
                        tableDato.Columns[property.Name].DataType = property.PropertyType;
                    }
                }

                //variable de conteo
                var contador = 1;
                var totalDatos = oleDatos.Count;


                foreach (OleDato dato in oleDatos)
                {
                    if (contador == 1)
                    {
                        if(tablaDatosDtos != null)tablaDatosDtos.Clear();
                        tablaDatosDtos = (List<TablaDatosDto>)_datoRepositoryQuery.GetAll((int)dato.SITE_NUMBER, (DateTime)dato.DATE, tabla);
                    }

                    if (tablaDatosDtos.FirstOrDefault(d => d.SERIAL_NUMBER == dato.SERIAL_NUMBER && d.SITE_NUMBER == dato.SITE_NUMBER && d.DATE == dato.DATE) != default)
                    {
                        writer.WriteLine("Archivo ya cargado: " + archivo);
                        return 2;
                    }

                    DataRow row = tableDato.NewRow();

                    foreach (var property in typeof(OleDato).GetProperties())
                    {
                        if(property.Name == "TIME")
                        {
                            row[property.Name] = dato.TIME.Value.TimeOfDay;
                        }
                        else
                        {
                            row[property.Name] = property.GetValue(dato) ?? DBNull.Value;
                        }
                    }

                    tableDato.Rows.Add(row);
                    contador++;
                }

                using (var connection = _dbContext.Create())
                {
                    using (var bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = tabla;
                        bulkCopy.WriteToServer(tableDato);
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                writer.WriteLine("Archivo: " + archivo + " - Fallo al cargar");
                return 0;
            }
        }
    }
}
