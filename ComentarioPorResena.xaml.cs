using AR_JC_ProyectoP2.Models;
using AR_JC_ProyectoP2.ViewModels;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AR_JC_ProyectoP2;

public partial class ComentarioPorResena : ContentPage
{
    private List<listaComentario> comentariosFiltrados;
    private ComentarioPorResenaViewModel _viewModel;
    public listaUsuarios user;
    public listaResena res;

    public ComentarioPorResena(listaResena resena, listaUsuarios usuario)
    {
        InitializeComponent();
        CargarComentarios(resena);
        _viewModel = (ComentarioPorResenaViewModel)BindingContext;
        _viewModel.Resena = resena;
        this.user = usuario;
        this.res = resena;
    }

    private async void CargarComentarios(listaResena resena)
    {
        comentariosFiltrados = await listarComentarios(resena);
        coleccion.ItemsSource = comentariosFiltrados;
    }

    public async Task<List<listaComentario>> listarComentarios(listaResena resena)
    {
        var idResena = resena.idResena;
        List<listaComentario> comentariosFiltrados = null;

        using (var client = new HttpClient())
        {
            var url = "https://localhost:7274/Comentario/ListarComentarios";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaComentario = JsonConvert.DeserializeObject<List<listaComentario>>(content);
                comentariosFiltrados = listaComentario.Where(r => r.idResenaF == idResena).ToList();
            }
        }

        return comentariosFiltrados;
    }

    private async void Enviar_Clicked(object sender, EventArgs e)
    {
        // Obtener los valores ingresados en los Entry
        string cuerpo = BodyEditor.Text;
        DateTime fechaComentario = DateTime.Now;
        string fechaComentarioFormatted = fechaComentario.ToString("yyyy-MM-ddTHH:mm:ss");
        int IdResena = res.idResena;
        int ID_User = user.idUser;

        // Validar que los campos no estén vacíos
        if (string.IsNullOrWhiteSpace(cuerpo))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
            return;
        }

        var newComentario = new listaComentario
        {
            cuerpo = cuerpo,
            fechaComentario = fechaComentario,
            idResenaF = IdResena,
            idUserF = ID_User
        };

        var json = JsonConvert.SerializeObject(newComentario);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using (var client = new HttpClient())
        {
            await DisplayAlert("Éxito", "fecha: "+fechaComentario.ToString(), "OK");
            var url = "https://localhost:7274/Comentario/AgregarComentario?idUsuario=" + ID_User + "&idResena=" + IdResena + "&Cuerpo=" + cuerpo + "&FechaComentario=" + fechaComentarioFormatted;
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "El comentario se creó correctamente.", "OK");
                //Metodo para que se actualice la ventana ComentarioPorResena.xaml y ahora muestra la lista de Comentario actualizada con el ultimo comentario agregado a la api 
                CargarComentarios(res);
            }
            else
            {
                await DisplayAlert("Error", "Error al crear el comentario. Por favor, intenta nuevamente.", "OK");
            }
        }
    }

}