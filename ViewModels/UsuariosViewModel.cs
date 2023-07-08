using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AR_JC_ProyectoP2.Models;
using Newtonsoft.Json;

namespace AR_JC_ProyectoP2.ViewModels
{
    public class UsuariosViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<listaUsuarios> _usuarios;
        public ObservableCollection<listaUsuarios> Usuarios
        {
            get { return _usuarios; }
            set
            {
                _usuarios = value;
                OnPropertyChanged();
            }
        }

        private listaUsuarios _selectedUsuario;
        public listaUsuarios SelectedUsuario
        {
            get { return _selectedUsuario; }
            set
            {
                _selectedUsuario = value;
                OnPropertyChanged();
            }
        }
        /*
        public UsuariosViewModel()
        {
            // Inicializar la lista de usuarios
            Usuarios = new ObservableCollection<listaUsuarios>();
            CargarUsuarios();
        }

        public void CargarUsuarios()
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:7171/Usuario/ListarUsuarios";
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    Usuarios = JsonConvert.DeserializeObject<ObservableCollection<listaUsuarios>>(json);
                }
            }
        }
        
        public void ActualizarUsuarios()
        {
            // Aquí iría el código para actualizar los usuarios desde la API o cualquier otra fuente de datos
            // Por ejemplo, si estás utilizando HttpClient para obtener los usuarios desde una API:

            using (var client = new HttpClient())
            {
                var url = "https://localhost:7144/Usuario/ListarUsuarios";
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    Usuarios = JsonConvert.DeserializeObject<ObservableCollection<listaUsuarios>>(json);
                }
            }
        }
        */

        // Implementación de la interfaz INotifyPropertyChanged para notificar cambios de propiedad
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
