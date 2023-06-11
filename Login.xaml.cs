using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class Login : ContentPage
{
    private ApplicationDbContext context;


    public Login()
	{
		InitializeComponent();
        context = new ApplicationDbContext();
    }

    async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string NombreUsuario = UserNameEntry.Text;
        string Contrasenia = passwordEntry.Text;
        var usuario = context.Usuario.FirstOrDefault(u => u.NombreUsuario == NombreUsuario && u.Contrasenia == Contrasenia);
        if (usuario != null)
        {
            // Datos de usuario válidos, navegar a la siguiente página
           await Navigation.PushAsync(new GestionUsuarios(usuario));
        }
        else
        {
            // Credenciales inválidas, mostrar mensaje de error
            await DisplayAlert("Error", "Credenciales inválidas", "OK");
        }
    }

    async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Navega a la página de registro (RegisterPage) y espera a que se complete la navegación.
        await Navigation.PushAsync(new RegisterPage());
        // El código aquí se ejecutará después de que se complete la navegación.
    }

}