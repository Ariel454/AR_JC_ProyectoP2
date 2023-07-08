using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AR_JC_ProyectoP2.Models;
namespace AR_JC_ProyectoP2.ViewModels
{
    public class ComentarioPorResenaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private listaResena _resena;
        public listaResena Resena
        {
            get { return _resena; }
            set
            {
                if (_resena != value)
                {
                    _resena = value;
                    OnPropertyChanged(nameof(Resena));
                }
            }
        }

        private List<listaComentario> _comentario;
        public List<listaComentario> Comentario
        {
            get { return _comentario; }
            set
            {
                if (_comentario != value)
                {
                    _comentario = value;
                    OnPropertyChanged(nameof(Comentario));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

