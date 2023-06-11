using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class GestionUsuarios : ContentPage
{
    private ApplicationDbContext context;
    private List<Usuario> usuarios;

	public GestionUsuarios(Usuario usuario)
    {
		InitializeComponent();
        context = new ApplicationDbContext();
        NombreLabel.Text = "Bienvenido, " + usuario.Nombre;

        // Cargar los usuarios desde la base de datos
        usuarios = context.Usuario.ToList();

        // Establecer la lista de usuarios como origen de datos del ListView
        UserListView.ItemsSource = usuarios;
    }

    private void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Obtener el usuario seleccionado en el ListView
        var usuarioSeleccionado = (Usuario)e.SelectedItem;

        // Realizar alguna acción con el usuario seleccionado
        // Ejemplo: mostrar los detalles del usuario en una página de detalles
        Navigation.PushAsync(new DetallesUsuario(usuarioSeleccionado));
    }

    private void OnAddUserClicked(object sender, EventArgs e)
    {
        // Navegar a la página de creación de usuario
        Navigation.PushAsync(new CrearUsuario());
    }

    private void OnEditUserClicked(object sender, EventArgs e)
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
}

    
