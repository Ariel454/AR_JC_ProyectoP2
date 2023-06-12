using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2;

public partial class MainPage : ContentPage
{
    int count = 0;
    private ApplicationDbContext context;
    private Usuario usuario;

    public MainPage(Usuario usuario)
    {
        InitializeComponent();
        this.usuario = usuario;
    }



    async private void Button_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var pelicula = button.BindingContext as Pelicula;
        await Navigation.PushAsync(new CrearResena(pelicula, usuario));
    }
}


