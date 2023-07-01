using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
namespace AR_JC_ProyectoP2;

public partial class CrearResena : ContentPage
{
    public Pelicula pelicula;
    public Usuario usuario;
    private ApplicationDbContext context;
    public CrearResena(Pelicula peli, Usuario user)
    {
        InitializeComponent();
        context = new ApplicationDbContext();
        this.pelicula = peli;
        this.usuario = user;
    }
    private void OnRolPickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        // Obtener los valores ingresados en los Entry y el Picker
        string Titulo = TituloEntry.Text;
        string Texto = TextoEntry.Text;
        int IdPelicula = pelicula.IdPelicula;
        int ID_User = usuario.ID_User;
        // Validar que los campos no est�n vac�os y que las contrase�as coincidan
        if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Texto))
        {
            DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        using (var context = new ApplicationDbContext())
        {
            var newResena = new Resena
            {
                Titulo = Titulo,
                Texto = Texto,
                IdPeliculaP = IdPelicula,
                ID_UserP = ID_User
            };

            context.Resenas.Add(newResena);
            context.SaveChanges();

            DisplayAlert("�xito", "La pelicula se public� correctamente.", "OK");
            Navigation.PopAsync();
            Navigation.PushAsync(new ResenaPorPelicula(newResena.IdPeliculaP, context.Resenas.ToList<Resena>()));

        }
        /*ESTO LO BORR� PORQUE ESTOY PROBANDO EL ORDEN DEL FINAL PARA RECUPERAR EL USUARIO Y LA PELI
        DisplayAlert("�xito", "La pelicula se public� correctamente.", "OK");
        Navigation.PopAsync();
        Navigation.PushAsync(new ResenaPorPelicula());
        */
    }
}