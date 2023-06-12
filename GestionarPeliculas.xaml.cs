using System.Windows.Input;
using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class GestionarPeliculas : ContentPage
{
    private ApplicationDbContext context;
    private List<Pelicula> listaPeliculas;
    public ICommand ModificarPeliculaCommand { get; private set; }

    public GestionarPeliculas()
    {
        InitializeComponent();
        context = new ApplicationDbContext();

        // Obtener las películas de la base de datos local
        listaPeliculas = ObtenerPeliculas();

        // Establecer el origen de datos para la colección de películas
        collectionView.ItemsSource = listaPeliculas;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var pelicula = button.BindingContext as Pelicula;

        // Navegar a la página de detalles de la película y pasar la película seleccionada como parámetro
        await Navigation.PushAsync(new ModificarPelicula(pelicula));
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
        // Navegar a la página de creación de usuario
        Navigation.PushAsync(new CrearPelicula());
    }

    /*private void OnEditUserClicked(object sender, EventArgs e)
    {
        // Obtener el usuario seleccionado en el ListView
        var usuarioSeleccionado = (Usuario)UserListView.SelectedItem;

        if (usuarioSeleccionado != null)
        {
            // Navegar a la página de edición de usuario pasando el usuario seleccionado como parámetro
            Navigation.PushAsync(new EditarUsuario(usuarioSeleccionado));
        }
        else
        {
            // Mostrar mensaje de error si no se ha seleccionado ningún usuario
            DisplayAlert("Error", "Seleccione un usuario para editar", "OK");
        }
        UserListView.ItemsSource = null;
        UserListView.ItemsSource = usuarios;
    }

    private async void OnDeleteUserClicked(object sender, EventArgs e)
    {
        // Obtener el usuario seleccionado en el ListView
        var usuarioSeleccionado = (Usuario)UserListView.SelectedItem;

        if (usuarioSeleccionado != null)
        {
            // Confirmar la eliminación del usuario
            bool result = await DisplayAlert("Confirmación", "¿Está seguro de eliminar este usuario?", "Sí", "No");

            if (result)
            {
                // Eliminar el usuario de la base de datos
                context.Usuario.Remove(usuarioSeleccionado);
                context.SaveChanges();

                // Actualizar la lista de usuarios y refrescar el ListView
                usuarios.Remove(usuarioSeleccionado);
                UserListView.ItemsSource = null;
                UserListView.ItemsSource = usuarios;
            }
        }
        else
        {
            // Mostrar mensaje de error si no se ha seleccionado ningún usuario
            await DisplayAlert("Error", "Seleccione un usuario para eliminar", "OK");
        }
    }
    */
}