using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
using Newtonsoft.Json;
using System.Text;

namespace AR_JC_ProyectoP2;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string NombreUsuario = UserNameEntry.Text;
        string Nombre = NombreEntry.Text;
        string Contrasenia = passwordEntry.Text;
        string ConfirmPassword = confirmPasswordEntry.Text;
        string Correo = emailEntry.Text;

        if (string.IsNullOrWhiteSpace(NombreUsuario) || string.IsNullOrWhiteSpace(Contrasenia) || string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        if (Contrasenia != ConfirmPassword)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        var newUsuario = new listaUsuarios
        {
            nombreUsuario = NombreUsuario,
            nombre = Nombre,
            contrasenia = Contrasenia,
            correo = Correo,
            rol = 2
        };

        var json = JsonConvert.SerializeObject(newUsuario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using (var client = new HttpClient())
        {
            var url = "https://localhost:7144/Usuario/RegistrarUsuario?Nombre=" + Nombre + "&Rol=2&NombreUser=" + NombreUsuario + "&Contrasena=" + Contrasenia + "&Correo=" + Correo;
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "El registro se realizó correctamente, por favor inicie sesión.", "OK");
                await Navigation.PushAsync(new Login());
            }
            else
            {
                await DisplayAlert("Error", "Error al crear el usuario. Por favor, intenta nuevamente.", "OK");
            }
        }
    }
}
