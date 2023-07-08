using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2.Models
{
    public class listaComentario
    {
        public int idComentario { get; set; }
        public int idResenaF { get; set; }
        public int idUserF { get; set; }
        public string cuerpo { get; set; }
        public DateTime fechaComentario { get; set; }
        public object idResenaFNavigation { get; set; }
        public object idUserFNavigation { get; set; }
    }


}
