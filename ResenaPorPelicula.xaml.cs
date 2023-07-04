using AR_JC_ProyectoP2.Models;
using AR_JC_ProyectoP2.ViewModels;
using AR_JC_ProyectoP2;
using Microsoft.Maui.Controls;

namespace AR_JC_ProyectoP2
{
    public partial class ResenaPorPelicula : ContentPage
    {
        private ResenaPorPeliculaViewModel _viewModel;

        public ResenaPorPelicula(Pelicula pelicula)
        {
            InitializeComponent();

            _viewModel = new ResenaPorPeliculaViewModel();
            _viewModel.Pelicula = pelicula;
            BindingContext = _viewModel;

            // Agregar código para obtener y establecer otras propiedades del ViewModel

        }
    }
}
