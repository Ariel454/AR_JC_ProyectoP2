using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class DetallesUsuario : ContentPage
{
    public DetallesUsuario(Usuario usuario)
    {
        String RolNombre;

        InitializeComponent();

        // Mostrar los detalles del usuario en los Labels correspondientes
        NombreLabel.Text = usuario.Nombre;
        CorreoLabel.Text = usuario.Correo;
        if (usuario.Rol == 0) {
            RolNombre = "Administrador";
        }
        else if(usuario.Rol == 1)
        {
            RolNombre = "Moderador";
        }
        else
        {
            RolNombre = "Usuario";
        }
        RolLabel.Text = RolNombre;


    }
}
