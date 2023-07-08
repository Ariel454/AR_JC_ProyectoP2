using AR_JC_ProyectoP2.Data;
using AR_JC_ProyectoP2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AR_JC_ProyectoP2
{
    public partial class MainPage : ContentPage
    {
        private List<listaPelicula> listaPeliculas;
        private listaUsuarios usuario;

        public MainPage(listaUsuarios usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            ObtenerPeliculas();
        }

        private async void ObtenerPeliculas()
        {
            List<listaPelicula> listaPeliculas = new List<listaPelicula>();

            try
            {
                
                using (var httpClient = new HttpClient())
                {
                    var url = "https://localhost:7144/Pelicula/ListarPeliculas";
                    var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        listaPeliculas = JsonConvert.DeserializeObject<List<listaPelicula>>(content);
                        collectionView.ItemsSource = listaPeliculas;
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo obtener la lista de películas.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            listaPelicula pelicula = button.BindingContext as listaPelicula;
            if (pelicula != null)
            {
                await Navigation.PushAsync(new CrearResena(pelicula, usuario));
            }
        }

        private async void ButtonVer_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            listaPelicula pelicula = button.BindingContext as listaPelicula;
            if (pelicula != null)
            {
                await Navigation.PushAsync(new ResenaPorPelicula(pelicula, usuario));
            }
        }

        private void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var usuarioSeleccionado = (listaUsuarios)e.SelectedItem;
            // Realizar alguna acción con el usuario seleccionado
            // Ejemplo: mostrar los detalles del usuario en una página de detalles
            // Navigation.PushAsync(new DetallesUsuario(usuarioSeleccionado));
        }

        private void OnCrearPeliculaClicked(object sender, EventArgs e)
        {
            // Implementa la funcionalidad para crear una nueva película
        }
    }
}

