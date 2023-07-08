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
    }
}
