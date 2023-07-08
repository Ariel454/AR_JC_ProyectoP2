using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
using Newtonsoft.Json;
using System.Data;

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
        string user = UserNameEntry.Text;
        string pass = passwordEntry.Text;

        using (var client = new HttpClient())
        {
            var url = "https://localhost:7274/Usuario/ListarUsuarios";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaUsuarios = JsonConvert.DeserializeObject<List<listaUsuarios>>(content);
                listaUsuarios usuario = listaUsuarios.FirstOrDefault(u => u.nombreUsuario == user && u.contrasenia == pass);

                if (usuario != null)
                {

                    if (usuario.rol == 2)
                    {
                        await Navigation.PushAsync(new MainPage(usuario));
                    }
                    else if (usuario.rol == 0)
                    {
                        await Navigation.PushAsync(new VistaLog());
                    }
                    else
                    {
                        // Credenciales inv�lidas, mostrar mensaje de error
                        await DisplayAlert("Error", "Usuario no autorizado", "OK");
                    }
                }
                else
                {
                    // Credenciales inv�lidas, mostrar mensaje de error
                    await DisplayAlert("Error", "Credenciales inv�lidas", "OK");
                }
            }
        }
    }



    async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Navega a la p�gina de registro (RegisterPage) y espera a que se complete la navegaci�n.
        await Navigation.PushAsync(new RegisterPage());
        // El c�digo aqu� se ejecutar� despu�s de que se complete la navegaci�n.
    }

}