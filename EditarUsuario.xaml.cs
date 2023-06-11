using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
using Microsoft.IdentityModel.Tokens;

namespace AR_JC_ProyectoP2;

public partial class EditarUsuario : ContentPage
{
    private Usuario user;
    public EditarUsuario(Usuario user)
    {
        InitializeComponent();

        // Asigna el usuario recibido al campo de instancia
        this.user = user;

        // Rellena los campos de entrada con los datos del usuario
        NombreEntry.Text = user.Nombre;
        CorreoEntry.Text = user.Correo;

        // Establece la selección del RolPicker en función del valor del campo "Rol" del usuario
        switch (user.Rol)
        {
            case 0:
                RolPicker.SelectedItem = "Administrador";
                break;
            case 1:
                RolPicker.SelectedItem = "Moderador";
                break;
            case 2:
                RolPicker.SelectedItem = "Usuario";
                break;
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        using (var context = new ApplicationDbContext())
        {

            // Obtiene el usuario desde el contexto y actualiza sus propiedades
            var updatedUser = context.Usuario.FirstOrDefault(u => u.ID_User == user.ID_User);
            if (updatedUser != null)
            {
                updatedUser.Nombre = NombreEntry.Text;
                updatedUser.Correo = CorreoEntry.Text;

                string rol = (string)RolPicker.SelectedItem;
                switch (rol)
                {
                    case "Administrador":
                        updatedUser.Rol = 0;
                        break;
                    case "Moderador":
                        updatedUser.Rol = 1;
                        break;
                    case "Usuario":
                        updatedUser.Rol = 2;
                        break;
                }

                // Guarda los cambios en la base de datos
                context.SaveChanges();
            }
        }

        // Muestra un mensaje de éxito
        DisplayAlert("Éxito", "Cambios guardados correctamente", "OK");
    }

    private void OnRolPickerSelectedIndexChanged(Object sender, EventArgs e) { 
    
    }
}