using AR_JC_ProyectoP2.Models;
using AR_JC_ProyectoP2.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2
{
    public partial class ResenaPorPelicula : ContentPage
    {
        private List<listaResena> resenasFiltradas;
        private ResenaPorPeliculaViewModel _viewModel;
        public listaUsuarios user;


        public ResenaPorPelicula(listaPelicula pelicula, listaUsuarios usuario)
        {
            InitializeComponent();
            CargarResenas(pelicula);
            _viewModel = (ResenaPorPeliculaViewModel)BindingContext;
            _viewModel.Pelicula = pelicula;
            this.user = usuario;
        }

        private async void CargarResenas(listaPelicula pelicula)
        {
            resenasFiltradas = await ListarResenas(pelicula);
            coleccion.ItemsSource = resenasFiltradas;
        }

        public async Task<List<listaResena>> ListarResenas(listaPelicula pelicula)
        {
            var idPelicula = pelicula.idPelicula;
            List<listaResena> resenasFiltradas = null;

            using (var client = new HttpClient())
            {
                var url = "https://localhost:7144/Resena/ListarResenas";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var listaResena = JsonConvert.DeserializeObject<List<listaResena>>(content);
                    resenasFiltradas = listaResena.Where(r => r.idPeliculaP == idPelicula).ToList();
                }
            }

            return resenasFiltradas;
        }

        private async void BtnResponder_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var resena = button.BindingContext as listaResena;
            await Navigation.PushAsync(new ComentarioPorResena(resena, user));
        }

        private async void ButtonVerTrailer_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            listaPelicula pelicula = _viewModel.Pelicula;
            if (pelicula != null)
            {
                // Obtener el videoId utilizando la API de YouTube
                string videoId = await GetYouTubeVideoId(pelicula.nombre);

                if (!string.IsNullOrEmpty(videoId))
                {
                    // Construir la URL del video
                    string videoUrl = $"https://www.youtube.com/watch?v={videoId}";


                    // Genera el código HTML para incrustar el video de YouTube
                    string html = $"<html><body><iframe width='100%' height='100%' src='https://www.youtube.com/embed/{videoId}' frameborder='0' allow='autoplay; encrypted-media' allowfullscreen></iframe></body></html>";

                    // Carga el código HTML en el WebView
                    webView.Source = new HtmlWebViewSource { Html = html };
                    //trailerLayout.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró el video de YouTube para la película.", "OK");
                }
            }
            // Obtén el ID del video de YouTube para la película seleccionada

        }




        private async Task<string> GetYouTubeVideoId(string movieName)
        {

            try
            {

                string apiKey = "AIzaSyD4GIJFGK5gYx7emy3KDXhscqtuv4EkmCg";

                using (HttpClient client = new HttpClient())
                {
                    // Realizar la solicitud a la API de búsqueda de YouTube
                    string requestUrl = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={Uri.EscapeDataString(movieName)}%20trailer&type=video&key={apiKey}";
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();
                        dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

                        if (responseObject != null && responseObject.items != null && responseObject.items.Count > 0)
                        {
                            string videoId = responseObject.items[0].id.videoId;
                            return videoId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el ID del video de YouTube: {ex.Message}");
            }

            return null;
        }
    }
}
