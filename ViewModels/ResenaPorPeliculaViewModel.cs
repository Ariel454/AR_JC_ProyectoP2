using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AR_JC_ProyectoP2.Models;
using AR_JC_ProyectoP2.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AR_JC_ProyectoP2.ViewModels
{
    public partial class ResenaPorPeliculaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Pelicula _pelicula;
        public Pelicula Pelicula
        {
            get { return _pelicula; }
            set
            {
                if (_pelicula != value)
                {
                    _pelicula = value;
                    OnPropertyChanged(nameof(Pelicula));
                }
            }
        }

        private ObservableCollection<Resena> _resenas;
        public ObservableCollection<Resena> Resenas
        {
            get { return _resenas; }
            set
            {
                if (_resenas != value)
                {
                    _resenas = value;
                    OnPropertyChanged(nameof(Resenas));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
