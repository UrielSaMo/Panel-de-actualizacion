using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panel_de_actualizacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            // Obtener la ruta del ejecutable actual
            string currentExecutablePath = Application.StartupPath;

            // Construir la ruta completa del ejecutable CalculadoraAreas.exe
            string exePath = Path.Combine(currentExecutablePath, "CalculadoraAreas.exe");

            try
            {
                // Iniciar el archivo .exe
                System.Diagnostics.Process.Start(exePath);

                // Cerrar la aplicación actual
                Application.Exit();
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar un mensaje con la descripción del problema
                MessageBox.Show($"Error al intentar ejecutar CalculadoraAreas.exe: {ex.Message}");
            }
        }


        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            // Definir la URL del repositorio directamente en el código
            string repoUrl = "https://github.com/UrielSaMo/ActualizacionCalculadoraAreas.git";

            // Obtener la ruta del ejecutable actual
            string currentExecutablePath = Application.StartupPath;
           
            string ejecucion = Path.Combine(currentExecutablePath, "CalculadoraAreas.exe");

            // Subir dos niveles para llegar a la carpeta deseada
            string basePath = Path.GetFullPath(Path.Combine(currentExecutablePath, @"..\..\..\"));

            // Ruta donde se clonará el repositorio (CalculadoraAreas2)
            string localPath = Path.Combine(basePath, "CalculadoraAreas2");

            // Comando git para clonar el repositorio
            string gitCommand = $"git clone {repoUrl} \"{localPath}\"";

            

            try
            {
                // Crear y configurar el proceso
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {gitCommand}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                // Iniciar el proceso
                process.Start();

                // Leer la salida del comando
                using (var reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    // Mostrar la salida en un MessageBox o en otro control si lo deseas
                    MessageBox.Show(result);
                }

                // Esperar a que termine
                process.WaitForExit();

                // Imprimir la ruta donde se clonó el repositorio
                MessageBox.Show($"El repositorio se ha clonado en: {localPath}");

                // Construir la ruta del .exe para ejecutar
                string exePath = Path.Combine(localPath, @"CalculadoraAreasParaActualizacion\bin\Debug\CalculadoraAreasParaActualizacion.exe");

                // Iniciar el .exe
                System.Diagnostics.Process.Start(exePath);
                process.WaitForExit();
                Application.Exit();

                /*
                // Ruta de la carpeta que deseas eliminar (CalculadoraAreas)
                string folderToDelete = Path.Combine(basePath, "CalculadoraAreas");

                // Verificar si la carpeta CalculadoraAreas existe y eliminarla
                if (Directory.Exists(folderToDelete))
                {
                    Directory.Delete(folderToDelete, true); // true para eliminar recursivamente
                    MessageBox.Show("La carpeta CalculadoraAreas ha sido eliminada.");
                }
                else
                {
                    MessageBox.Show("La carpeta CalculadoraAreas no existe.");
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar clonar el repositorio: {ex.Message}");
            }
            
        }




    }
}

// actualizar el programa
// iniciar el proyecto
// Presionar el bon sctualizar 
// Abrir una segunda app para realizar la actualizacion 
// permitir actualizacion ( eliminar paquetes y descargar nuevos)
// abri nueva aplicacion (boton actualizar eliminado)
// string exePath = Path.Combine(localPath, @"CalculadoraAreasParaActualizacion\bin\Debug\CalculadoraAreasParaActualizacion.exe");
