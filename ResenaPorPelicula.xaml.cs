using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class ResenaPorPelicula : ContentPage
{
    private ApplicationDbContext context;
    private List<Pelicula> listaPeliculas;
    private Pelicula pelicula;
    private Usuario usuario;
    public List<Resena> Resenas { get; set; }
    public ResenaPorPelicula(int IdPelicula, List<Resena> resenas)
    {
        InitializeComponent();
        // Obtener las películas de la base de datos local
        listaPeliculas = ObtenerPeliculas();

        // Establecer el origen de datos para la colección de películas
        collectionView.ItemsSource = listaPeliculas;

        this.pelicula = pelicula;
        this.usuario = usuario;

        Pelicula p1 = new Pelicula();
        p1.Resenas = resenas; // Asigna la lista de reseñas a la propiedad "Resenas" de la instancia de Pelicula

        BindingContext = p1; // Asigna la instancia de Pelicula como contexto de datos para el enlace de datos en XAML

        Resenas = resenas;
        BindingContext = this;
        BindingContext = resenas;

    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var pelicula = button.BindingContext as Pelicula;
        if (pelicula != null)
        {
            await Navigation.PushAsync(new CrearResena(pelicula, usuario));
        }
        //var usuario = ObtenerUsuarioActual(); // Reemplaza ObtenerUsuarioActual() con la lógica para obtener el usuario actual


    }




    private List<Pelicula> ObtenerPeliculas()
    {
        using (var context = new ApplicationDbContext())
        {
            return context.Peliculas.ToList();
        }
    }



    private void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Obtener el usuario seleccionado en el ListView
        var usuarioSeleccionado = (Usuario)e.SelectedItem;

        // Realizar alguna acción con el usuario seleccionado
        // Ejemplo: mostrar los detalles del usuario en una página de detalles
        //Navigation.PushAsync(new DetallesUsuario(usuarioSeleccionado));
    }

    private void OnCrearPeliculaClicked(object sender, EventArgs e)
    {

    }
}


