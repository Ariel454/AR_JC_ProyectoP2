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

        // Obtener las pel�culas de la base de datos local
        listaPeliculas = ObtenerPeliculas();

        // Establecer el origen de datos para la colecci�n de pel�culas
        collectionView.ItemsSource = listaPeliculas;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var pelicula = button.BindingContext as Pelicula;

        // Navegar a la p�gina de detalles de la pel�cula y pasar la pel�cula seleccionada como par�metro
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

        // Realizar alguna acci�n con el usuario seleccionado
        // Ejemplo: mostrar los detalles del usuario en una p�gina de detalles
        //Navigation.PushAsync(new DetallesUsuario(usuarioSeleccionado));
    }
    private void OnCrearPeliculaClicked(object sender, EventArgs e)
    {
        // Navegar a la p�gina de creaci�n de usuario
        Navigation.PushAsync(new CrearPelicula());
    }

    /*private void OnEditUserClicked(object sender, EventArgs e)
    {
        // Obtener el usuario seleccionado en el ListView
        var usuarioSeleccionado = (Usuario)UserListView.SelectedItem;

        if (usuarioSeleccionado != null)
        {
            // Navegar a la p�gina de edici�n de usuario pasando el usuario seleccionado como par�metro
            Navigation.PushAsync(new EditarUsuario(usuarioSeleccionado));
        }
        else
        {
            // Mostrar mensaje de error si no se ha seleccionado ning�n usuario
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
            // Confirmar la eliminaci�n del usuario
            bool result = await DisplayAlert("Confirmaci�n", "�Est� seguro de eliminar este usuario?", "S�", "No");

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
            // Mostrar mensaje de error si no se ha seleccionado ning�n usuario
            await DisplayAlert("Error", "Seleccione un usuario para eliminar", "OK");
        }
    }
    */
}