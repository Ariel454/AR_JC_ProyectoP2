using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Pelicula")]
        public int IdPeliculaP { get; set; }

        public Usuario Usuario { get; set; }
        [ForeignKey("Usuario")]
        public int ID_UserP { get; set; }
    }
}
