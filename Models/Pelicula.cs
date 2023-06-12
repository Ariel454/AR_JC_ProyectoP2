using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2.Models
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Html)]
        public string Descripcion { get; set; }
        public string Genero { get; set; }
        public int anio { get; set; }
        public string Poster { get; set; }


    }
}
