using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace AR_JC_ProyectoP2.ViewModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class listaPeliculaViewModel
    {
        public int idPelicula { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string genero { get; set; }
        public int anio { get; set; }
        public string poster { get; set; }
        public List<object> resenas { get; set; }
    }


}
