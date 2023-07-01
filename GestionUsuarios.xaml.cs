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
        NombreLabel.Text = "Bienvenido usuario Administrador: " + usuario.Nombre;

        // Cargar los usuarios desde la base de datos
        usuarios = context.Usuarios.ToList();

        // Establecer la lista de usuarios como origen de datos del ListView
        UserListView.ItemsSource = usuarios;
    }

    private void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Obtener el usuario seleccionado en el ListView
        var usuarioSeleccionado = (Usuario)e.SelectedItem;

        // Realizar alguna acci�n con el usuario seleccionado
        // Ejemplo: mostrar los detalles del usuario en una p�gina de detalles
        Navigation.PushAsync(new DetallesUsuario(usuarioSeleccionado));
    }

    private void OnAddUserClicked(object sender, EventArgs e)
    {
        // Navegar a la p�gina de creaci�n de usuario
        Navigation.PushAsync(new CrearUsuario());
    }

    private void OnEditUserClicked(object sender, EventArgs e)
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
                context.Usuarios.Remove(usuarioSeleccionado);
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
}

    
