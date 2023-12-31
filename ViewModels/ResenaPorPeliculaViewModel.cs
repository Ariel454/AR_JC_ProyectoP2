﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AR_JC_ProyectoP2.Models;
namespace AR_JC_ProyectoP2.ViewModels
{
    public class ResenaPorPeliculaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private listaPelicula _pelicula;
        public listaPelicula Pelicula
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

        private List<listaResena> _resenas;
        public List<listaResena> Resenas
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

