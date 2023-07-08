using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace AR_JC_ProyectoP2
{
    public partial class CrearResena : ContentPage
    {
        public listaPelicula pelicula;
        public listaUsuarios usuario;
        private ApplicationDbContext context;

        public CrearResena(listaPelicula peli, listaUsuarios user)
        {
            InitializeComponent();
            context = new ApplicationDbContext();
            this.pelicula = peli;
            this.usuario = user;
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            // Obtener los valores ingresados en los Entry
            string Titulo = TituloEntry.Text;
            string Texto = TextoEntry.Text;
            int IdPelicula = pelicula.idPelicula;
            int ID_User = usuario.idUser;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Texto))
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos.", "OK");
                return;
            }

            var newResena = new listaResena
            {
                titulo = Titulo,
                descripcion = Texto,
                idPeliculaP = IdPelicula,
                idUserP = ID_User
            };

            var json = JsonConvert.SerializeObject(newResena);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var url = "https://localhost:7144/Resena/AnadirResena?Titulo="+Titulo+"&Descripcion="+Texto+"&idPeliculaP="+IdPelicula+"&idUserP="+ID_User;
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var url2 = "https://localhost:7144/Resena/ListarResenas";
                    var response2 = await client.GetAsync(url2);
                    if (response2.IsSuccessStatusCode)
                    {
                        var content2 = await response2.Content.ReadAsStringAsync();
                        var listaResenas = JsonConvert.DeserializeObject<List<listaResena>>(content2);
                        listaResena res = listaResenas.LastOrDefault();
                        int nuevaResenaId = res.idResena;
                        await App.LogRepo.AddNewLog(nuevaResenaId);
                        await DisplayAlert("Éxito", "La reseña se creó correctamente. IdNuevo: " + nuevaResenaId, "OK");
                        await Navigation.PushAsync(new ResenaPorPelicula(pelicula, usuario));
                    }

                    
                }
                else
                {
                    await DisplayAlert("Error", "Error al crear la reseña. Por favor, intenta nuevamente.", "OK");
                }
            }
        }
    }
}
