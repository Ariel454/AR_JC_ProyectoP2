using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class CrearUsuario : ContentPage
{
	public CrearUsuario()
	{
		InitializeComponent();
	}

    private void OnCreateClicked(object sender, EventArgs e)
    {
        // Obtener los valores ingresados en los Entry y el Picker
        string NombreUsuario = UserNameEntry.Text;
        string Nombre = NombreEntry.Text;
        string Contrasenia = passwordEntry.Text;
        string ConfirmPassword = confirmPasswordEntry.Text;
        string Correo = emailEntry.Text;
        string rol = (string)RolPicker.SelectedItem;
        int Rol;

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
        
        if (rol == "Administrador")
        {
            Rol = 0;
        }
        else if (rol == "Moderador")
        {
            Rol = 1;
        }
        else
        {
            Rol = 2;
        }

        using (var context = new ApplicationDbContext())
        {
            bool usuarioExistente = context.Usuarios.Any(u => u.NombreUsuario == NombreUsuario);
            bool correoExistente = context.Usuarios.Any(u => u.Correo == Correo);
            if (usuarioExistente)
            {
                DisplayAlert("Error", "El nombre de usuario ya existe, por favor escriba uno nuevo.", "OK");
                return;
            }

            if (correoExistente)
            {
                DisplayAlert("Error", "El correo ya está registrado, por favor ingrese uno nuevo o inicie sesión.", "OK");
                return;
            }

            var newUsuario = new Usuario
            {
                NombreUsuario = NombreUsuario,
                Nombre = Nombre,
                Contrasenia = Contrasenia,
                Correo = Correo,
                Rol = Rol
            };

            context.Usuarios.Add(newUsuario);
            context.SaveChanges();
        }

        DisplayAlert("Éxito", "El registro se realizó correctamente.", "OK");
        Navigation.PopAsync();
    }

    private void OnRolPickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }
}