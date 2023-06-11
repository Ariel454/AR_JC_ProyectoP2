using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string NombreUsuario = UserNameEntry.Text;
        string Nombre = NombreEntry.Text;
        string Contrasenia = passwordEntry.Text;
        string ConfirmPassword = confirmPasswordEntry.Text;
        string Correo = emailEntry.Text;
        int Rol=0;

        // Validar que los campos no estén vacíos y que las contraseñas coincidan
        if (string.IsNullOrWhiteSpace(NombreUsuario) || string.IsNullOrWhiteSpace(Contrasenia) || string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        if (Contrasenia != ConfirmPassword)
        {
            DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        using (var context = new ApplicationDbContext())
        {
            var newUsuario = new Usuario
            {
                NombreUsuario = NombreUsuario,
                Nombre = Nombre,
                Contrasenia = Contrasenia,
                Correo = Correo,
                Rol = Rol
            };

            context.Usuario.Add(newUsuario);
            context.SaveChanges();
        }

        DisplayAlert("Éxito", "El registro se realizó correctamente.", "OK");
        Navigation.PopAsync();
    }

}