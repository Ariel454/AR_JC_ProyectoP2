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
            // Datos de usuario v�lidos, navegar a la siguiente p�gina
           await Navigation.PushAsync(new GestionUsuarios(usuario));
        }
        else
        {
            // Credenciales inv�lidas, mostrar mensaje de error
            await DisplayAlert("Error", "Credenciales inv�lidas", "OK");
        }
    }

    async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Navega a la p�gina de registro (RegisterPage) y espera a que se complete la navegaci�n.
        await Navigation.PushAsync(new RegisterPage());
        // El c�digo aqu� se ejecutar� despu�s de que se complete la navegaci�n.
    }

}