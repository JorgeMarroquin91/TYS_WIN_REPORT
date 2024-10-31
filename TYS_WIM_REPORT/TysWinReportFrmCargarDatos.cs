using System.Reflection.Metadata.Ecma335;
using TYS_WIM_REPORT.Helper;
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Properties;
using TYS_WIM_REPORT.Repositorios.Commands;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmCargarDatos : Form
    {
        private readonly EstacionRepositoryQuery _estacionRepositoryQuery = new EstacionRepositoryQuery();
        private readonly OleDatoRepositoryQuery _oleDatoRepositoryQuery = new OleDatoRepositoryQuery();
        private readonly DatoRepositoryQuery _datoRepositoryQuery = new DatoRepositoryQuery();
        private readonly DatoRepositoryCommand _datoRepositoryCommand = new DatoRepositoryCommand();
        private readonly EstacionDatosRepositoryQuery _estacionDatosRepositoryQuery = new EstacionDatosRepositoryQuery();
        private readonly EstacionDatosRepositoryCommand _estacionDatosRepositoryCommand = new EstacionDatosRepositoryCommand();
        private Reloj reloj = new Reloj();
        private Task<int> subir;
        StreamWriter writer;
        public TysWinReportFrmCargarDatos()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmCargarDatos_Load(object sender, EventArgs e)
        {
            this.llenarEstacion();
        }

        private void llenarEstacion()
        {
            var estaciones = _estacionRepositoryQuery.GetAll();

            cbxEstacion.DataSource = estaciones;
            cbxEstacion.DisplayMember = "nombreEstacion";
            cbxEstacion.ValueMember = "idEstacion";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            if (chkTodas.Checked)
            {
                this.mostrarLabels();
                var carpetas = this.leerCarpeta();
                writer = new StreamWriter(Settings.Default.directorioOrigen + "\\Log " + DateTime.UtcNow.ToLongDateString() + " - " + DateTime.UtcNow.Hour.ToString() + " - " + DateTime.UtcNow.Minute.ToString() + " - " + DateTime.UtcNow.Second.ToString());
                this.hayEstaciones(carpetas);

                if (carpetas.Count > 0)
                {
                    foreach (var carpeta in carpetas)
                    {
                        var archivos = this.leerArchivo(carpeta);
                        var totalArchivos = archivos.Count;

                        if (archivos.Count > 0)
                        {
                            progressBar1.Maximum = totalArchivos;
                            progressBar1.Minimum = 0;
                            progressBar1.Value = 0;

                            foreach (var archivo in archivos)
                            {
                                reloj.startReloj(lblCarga);
                                lblProgresBar.Text = "Estación: " + carpeta + "\nCargando: " + archivo + " -- Total: " + totalArchivos;

                                await this.cargarDatos(archivo, carpeta);

                                reloj.stopReloj();
                                progressBar1.Value += 1;
                            }
                        }
                        else
                        {
                            writer.WriteLine("No hay archivos en: " + carpeta);
                        }
                    }
                }
                else
                {
                    writer.WriteLine("No hay carpetas en: " + Settings.Default.directorioOrigen);
                }

                writer.Close();
                writer.Dispose();
            }
            else
            {
                Boolean hayCarpeta = false;
                Estacion? estacion = cbxEstacion.SelectedItem as Estacion;

                this.mostrarLabels();
                var carpetas = this.leerCarpeta();
                writer = new StreamWriter(Settings.Default.directorioOrigen + "\\Log " + DateTime.UtcNow.ToLongDateString() + " - " + DateTime.UtcNow.Hour.ToString() + " - " + DateTime.UtcNow.Minute.ToString() + " - " + DateTime.UtcNow.Second.ToString());
                this.hayEstaciones(carpetas);

                if (estacion != null)
                {
                    if (carpetas.Count > 0)
                    {
                        foreach (var carpeta in carpetas)
                        {
                            if (Convert.ToInt32(carpeta) == estacion.numeroEstacion)
                            {
                                hayCarpeta = true;
                                var archivos = this.leerArchivo(carpeta);
                                var totalArchivos = archivos.Count;

                                if (archivos.Count > 0)
                                {
                                    progressBar1.Maximum = totalArchivos;
                                    progressBar1.Minimum = 0;

                                    foreach (var archivo in archivos)
                                    {
                                        reloj.startReloj(lblCarga);
                                        lblProgresBar.Text = "Estación: " + carpeta + "\nCargando: " + archivo + " -- Total: " + totalArchivos;

                                        await this.cargarDatos(archivo, carpeta);

                                        reloj.stopReloj();
                                        progressBar1.Value += 1;
                                    }
                                }
                                else
                                {
                                    writer.WriteLine("No hay archivos en: " + carpeta);
                                }
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine("No hay carpetas en: " + Settings.Default.directorioOrigen);
                    }

                    if (!hayCarpeta)
                    {
                        writer.WriteLine("No existe carpeta para la estación: " + estacion.numeroEstacion);
                    }
                }

                writer.Close();
                writer.Dispose();
            }

            this.ocultarLabels();
        }

        private async Task cargarDatos(string archivo, string carpeta)
        {
            if (string.Equals(Path.GetExtension(archivo), ".mdb"))
            {
                var datos = _oleDatoRepositoryQuery.GetAll(archivo, carpeta);
                var tabla = this.obtenerEstacion(archivo, carpeta);

                subir = new Task<int>(() => _datoRepositoryCommand.CreateBulk(datos, writer, archivo, tabla));
                subir.Start();
                var subirTerminado = await subir;

                if (subirTerminado == 1)
                {
                    writer.WriteLine("Archivo: " + archivo + " - Cargado exitosamente");

                    if (Directory.Exists(Settings.Default.directorioDestino + "\\" + carpeta))
                    {
                        if (File.Exists(Settings.Default.directorioDestino + "\\" + carpeta + "\\" + archivo))
                        {
                            File.Delete(Settings.Default.directorioDestino + "\\" + carpeta + "\\" + archivo);
                            File.Move(Settings.Default.directorioOrigen + "\\" + carpeta + "\\" + archivo, Settings.Default.directorioDestino + "\\" + carpeta + "\\" + archivo);
                        }
                        else
                        {
                            File.Move(Settings.Default.directorioOrigen + "\\" + carpeta + "\\" + archivo, Settings.Default.directorioDestino + "\\" + carpeta + "\\" + archivo);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(Settings.Default.directorioDestino + "\\" + carpeta);
                        File.Move(Settings.Default.directorioOrigen + "\\" + carpeta + "\\" + archivo, Settings.Default.directorioDestino + "\\" + carpeta + "\\" + archivo);
                    }
                }else if (subirTerminado == 0 || subirTerminado == 2)
                {
                    if (Directory.Exists(Settings.Default.directorioError + "\\" + carpeta))
                    {
                        if (File.Exists(Settings.Default.directorioError + "\\" + carpeta + "\\" + archivo))
                        {
                            File.Delete(Settings.Default.directorioError + "\\" + carpeta + "\\" + archivo);
                            File.Move(Settings.Default.directorioOrigen + "\\" + carpeta + "\\" + archivo, Settings.Default.directorioError + "\\" + carpeta + "\\" + archivo);
                        }
                        else
                        {
                            File.Move(Settings.Default.directorioOrigen + "\\" + carpeta + "\\" + archivo, Settings.Default.directorioError + "\\" + carpeta + "\\" + archivo);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(Settings.Default.directorioError + "\\" + carpeta);
                        File.Move(Settings.Default.directorioOrigen + "\\" + carpeta + "\\" + archivo, Settings.Default.directorioError + "\\" + carpeta + "\\" + archivo);
                    }
                }
                
            }
            else
            {
                writer.WriteLine("Archivo no valido: " + archivo);
            }
        }

        //Funcion para leer las carpetas
        private List<string> leerCarpeta()
        {
            List<string> files = new List<string>();

            try
            {
                string[] archivos = Directory.GetDirectories(Settings.Default.directorioOrigen);

                foreach (string archivo in archivos)
                {
                    files.Add(Path.GetFileName(archivo));
                }

                return files;
            }
            catch (Exception ex)
            {
                return files;
            }
        }

        //Funcion para leer los archivos
        private List<string> leerArchivo(string carpeta)
        {
            List<string> files = new List<string>();

            try
            {
                string[] archivos = Directory.GetFiles(Settings.Default.directorioOrigen + "\\" + carpeta);

                foreach (string archivo in archivos)
                {
                    files.Add(Path.GetFileName(archivo));
                }

                return files;
            }
            catch (Exception ex)
            {
                return files;
            }
        }

        private void ocultarLabels()
        {
            lblProgresBar.Visible = false;
            lblProgresBar.Refresh();
            progressBar1.Visible = false;
            progressBar1.Refresh();
            lblCarga.Visible = false;
            lblCarga.Refresh();
            label3.Visible = false;
            label3.Refresh();
        }

        private void mostrarLabels()
        {
            lblProgresBar.Visible = true;
            lblProgresBar.Refresh();
            progressBar1.Visible = true;
            progressBar1.Refresh();
            lblCarga.Visible = true;
            lblCarga.Refresh();
            label3.Visible = true;
            label3.Refresh();
        }

        private void hayEstaciones(List<String> carpetas)
        {
            lblProgresBar.Text = "Comprobando que existan las estaciones...";
            Refresh();

            foreach (var carpeta in carpetas)
            {
                var archivos = leerArchivo(carpeta);

                foreach (var archivo in archivos)
                {
                    var fecha = archivo.Substring(0, archivo.Length - 4);
                    var anio = fecha.Substring(fecha.Length - 4, 4);

                    var estacion = _estacionRepositoryQuery.GetOne(numeroEstacion: Convert.ToInt32(carpeta));

                    if (estacion.idEstacion != null)
                    {
                        var estacionDatos = _estacionDatosRepositoryQuery.GetOne(estacion.nombreEstacion + anio, estacion.idEstacion);

                        if (estacionDatos.idEstacionDatos == null)
                        {
                            EstacionDatos datosEstacion = new();
                            datosEstacion.tabla = estacion.nombreEstacion + anio;
                            datosEstacion.idEstacion = estacion.idEstacion;
                            _estacionDatosRepositoryCommand.Create(datosEstacion);
                        }
                    }
                    else
                    {
                        writer.WriteLine("La estación : " + carpeta + " no existe");
                    }
                }
            }
        }

        private string obtenerEstacion(string archivo, string carpeta)
        {
            EstacionDatos estacionDatos = new();
            var fecha = archivo.Substring(0, archivo.Length - 4);
            var anio = fecha.Substring(fecha.Length - 4, 4);

            var estacion = _estacionRepositoryQuery.GetOne(numeroEstacion: Convert.ToInt32(carpeta));

            if (estacion.idEstacion != null)
            {
                estacionDatos = _estacionDatosRepositoryQuery.GetOne(estacion.nombreEstacion + anio, estacion.idEstacion);
            }

            return estacionDatos.tabla;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reloj.start)
            {
                reloj.addSecond(lblCarga);
            }
        }
    }
}
