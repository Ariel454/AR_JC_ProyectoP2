using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2.Models
{
    public class listaResena
    {
        [JsonProperty("idResena")]
        public int idResena { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int idPeliculaP { get; set; }
        public int idUserP { get; set; }
        public List<object> comentarios { get; set; }
        public object idPeliculaPNavigation { get; set; }
        public object idUserPNavigation { get; set; }
    }
}
