using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2.Models
{
    public class Resena
    {
        [Key]
        public int IdResena { get; set; }
        public string Titulo { get; set; }
        [DataType(DataType.Html)]
        public string Texto { get; set; }

        public Pelicula Pelicula { get; set; }
        public int IdPeliculaP { get; set; }

        public Usuario Usuario { get; set; }
        public int ID_UserP { get; set; }
    }
}
