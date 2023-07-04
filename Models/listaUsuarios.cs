using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class listaUsuarios
    {
        public int idUser { get; set; }
        public int rol { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasenia { get; set; }
        public string correo { get; set; }
        public List<object> comentarios { get; set; }
        public List<object> resenas { get; set; }
    }


}
