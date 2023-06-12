using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class ModificarPelicula : ContentPage
{
    private Pelicula peli;
    public ModificarPelicula(Pelicula peli)
    {
        InitializeComponent();
        // Asigna el usuario recibido al campo de instancia
        this.peli = peli;

        // Rellena los campos de entrada con los datos del usuario
        NombreEntry.Text = peli.Nombre;
        DescripcionEntry.Text = peli.Descripcion;
        AnioEntry.Text = peli.anio.ToString();
        PosterEntry.Text = peli.Poster;
        GeneroPicker.SelectedItem = peli.Genero;
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        using (var context = new ApplicationDbContext())
        {

            // Obtiene el usuario desde el contexto y actualiza sus propiedades
            var updatedPelicula = context.Peliculas.FirstOrDefault(u => u.Nombre == peli.Nombre);
            if (updatedPelicula != null)
            {
                updatedPelicula.Nombre = NombreEntry.Text;
                updatedPelicula.Descripcion = DescripcionEntry.Text;
                int Anio;
                updatedPelicula.Poster = PosterEntry.Text;
                updatedPelicula.Genero = (string)GeneroPicker.SelectedItem;

                // Guarda los cambios en la base de datos
                if (int.TryParse(AnioEntry.Text, out Anio))
                {
                    updatedPelicula.anio = Anio;
                    context.SaveChanges();
                }

            }
        }

        // Muestra un mensaje de éxito
        DisplayAlert("Éxito", "Cambios guardados correctamente", "OK");
        Navigation.PushAsync(new GestionarPeliculas());
    }

    private void OnRolPickerSelectedIndexChanged(Object sender, EventArgs e)
    {

    }
}