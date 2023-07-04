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
            var url = "https://localhost:7171/Usuario/listar";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
                var usuario = listaUsuarios.FirstOrDefault(u => u.NombreUsuario == user && u.Contrasenia == pass);
                if (usuario != null)
                {
                    // Datos de usuario válidos, navegar a la siguiente página
                    switch (usuario.Rol)
                    {
                        case 0:
                            await Navigation.PushAsync(new GestionUsuarios(usuario));
                            break;
                        case 2:
                            await Navigation.PushAsync(new MainPage(usuario));
                            break;
                        default:
                            await DisplayAlert("Alerta", "Usted no es administrador.", "OK");
                            break;
                    }
                }
                else
                {
                    // Credenciales inválidas, mostrar mensaje de error
                    await DisplayAlert("Error", "Credenciales inválidas", "OK");
                }
            }
        }
    }


    async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Navega a la página de registro (RegisterPage) y espera a que se complete la navegación.
        await Navigation.PushAsync(new RegisterPage());
        // El código aquí se ejecutará después de que se complete la navegación.
    }

}