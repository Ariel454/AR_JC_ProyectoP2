using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AR_JC_ProyectoP2
{
    public partial class Comentarios : ContentPage
    {
        private ICommand guardarComentarioCommand;
        private Usuario usuario; 

        public Comentarios(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void GuardarComentario(object sender, EventArgs e)
        {
            string titulo = TitleEntry.Text;
            string cuerpo = BodyEditor.Text;

            // Generar un nombre �nico para el archivo de texto (por ejemplo, utilizando una combinaci�n de la fecha/hora actual)
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            // Crear el contenido del archivo
            string fileContent = $"T�tulo: {titulo}{Environment.NewLine}Cuerpo: {cuerpo}";

            // Ruta completa del archivo (puedes ajustar la ubicaci�n seg�n tus necesidades)
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            // Guardar el contenido en el archivo
            File.WriteAllText(filePath, fileContent);

            // Aqu� puedes agregar la l�gica para guardar la ruta del archivo en tu base de datos local
            GuardarRutaArchivoEnBaseDeDatos(filePath);
        }

        private void GuardarRutaArchivoEnBaseDeDatos(string rutaArchivo)
        {
            // Aqu� debes agregar la l�gica para guardar la ruta del archivo en tu base de datos.
            // Utiliza tu mecanismo de acceso a la base de datos y ejecuta la consulta correspondiente.
            // Por ejemplo, puedes usar Entity Framework para interactuar con tu base de datos.
            // A continuaci�n se muestra un ejemplo utilizando Entity Framework:

            using (var dbContext = new ApplicationDbContext())
            {

                int idUsuario = usuario.ID_User;
                // Crea una instancia del modelo de datos de comentario y establece los valores
                var comentario = new Comentario
                {
                    ID_UserF = idUsuario,
                    Titulo = TitleEntry.Text,
                    Cuerpo = BodyEditor.Text,
                    RutaArchivo = rutaArchivo,
                    FechaComentario = DateTime.Now
                };

                // Agrega el comentario a la tabla de comentarios en tu base de datos
                dbContext.Comentario.Add(comentario);
                dbContext.SaveChanges();
            }
        }
    }
}