using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class CrearPelicula : ContentPage
{
    private Pelicula peli;
    public CrearPelicula()
    {
        InitializeComponent();
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        // Obtener los valores ingresados en los Entry y el Picker
        string Nombre = NombreEntry.Text;
        string Descripcion = DescripcionEntry.Text;
        int Anio;
        string Poster = PosterEntry.Text;
        string Genero = (string)generoPicker.SelectedItem;

        // Validar que los campos no estén vacíos y que las contraseñas coincidan
        if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Descripcion) || string.IsNullOrWhiteSpace(Poster))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        using (var context = new ApplicationDbContext())
        {
            bool peliculaExistente = context.Peliculas.Any(u => u.Nombre == Nombre);
            if (peliculaExistente)
            {
                DisplayAlert("Error", "La pelicula ya existe, por favor corrija.", "OK");
                return;
            }

            if (int.TryParse(AnioEntry.Text, out Anio))
            {
                // El valor se ha convertido correctamente a entero y se encuentra en la variable "Anio".
                // Puedes utilizar el valor de "Anio" en tu lógica de programación.
                var newPelicula = new Pelicula
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    anio = Anio,
                    Genero = Genero,
                    Poster = Poster
                };

                context.Peliculas.Add(newPelicula);
                context.SaveChanges();
            }



        }

        DisplayAlert("Éxito", "La pelicula se publicó correctamente.", "OK");
        Navigation.PopAsync();
    }

    private void OnRolPickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }
}