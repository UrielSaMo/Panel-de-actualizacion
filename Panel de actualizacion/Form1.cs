using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Application.Exit();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            // Obtiene la ruta del directorio donde se encuentra el ejecutable
            string ruta = Application.StartupPath;

            // Define la ruta completa de la nueva carpeta
            string nuevaCarpeta = System.IO.Path.Combine(ruta, "prueba");

            // Verifica si la carpeta ya existe
            if (!System.IO.Directory.Exists(nuevaCarpeta))
            {
                // Crea la carpeta
                System.IO.Directory.CreateDirectory(nuevaCarpeta);
            }

            // URL del repositorio
            string repoUrl = "https://github.com/UrielSaMo/CalculadoraAreasParaActualizacion.git";

            // Comando Git para clonar el repositorio
            string gitCommand = $"git clone {repoUrl} \"{nuevaCarpeta}\"";

            // Ejecutar el comando de Git
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {gitCommand}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                process.WaitForExit();
                MessageBox.Show("Repositorio clonado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al clonar el repositorio: {ex.Message}");
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
