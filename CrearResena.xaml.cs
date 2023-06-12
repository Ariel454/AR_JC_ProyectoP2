using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
namespace AR_JC_ProyectoP2;

public partial class CrearResena : ContentPage
{
    private Pelicula peli;
    public List<string> NombresPeliculas { get; set; }
    private readonly ApplicationDbContext _context;

    public CrearResena(Pelicula peli, Usuario usuario)
    {
        InitializeComponent();
        // Obtener los nombres de las películas desde ApplicationDbContext
        NombresPeliculas = _context.Peliculas.Select(p => p.Nombre).ToList();

        // Asignar la lista como origen de datos del Picker
        PeliculaPicker.ItemsSource = NombresPeliculas;
    }
    private void OnRolPickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        // Obtener los valores ingresados en los Entry y el Picker
        string Titulo = TituloEntry.Text;
        string Texto = TextoEntry.Text;

        // Validar que los campos no estén vacíos y que las contraseñas coincidan
        if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Texto))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        using (var context = new ApplicationDbContext())
        {
            var newResena = new Resena
            {
                Titulo = Titulo,
                Texto = Texto
            };

            //context.Resenas.Add(newResena);
            context.SaveChanges();



        }

        DisplayAlert("Éxito", "La pelicula se publicó correctamente.", "OK");
        Navigation.PopAsync();
    }
}