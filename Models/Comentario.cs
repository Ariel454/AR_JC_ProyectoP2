using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR_JC_ProyectoP2.Models
{
    public class Comentario
    {
        [Key]
        public int ID_Comentario { get; set; }

        [ForeignKey("Resena")]
        public int ID_ResenaF{ get; set; }

        [ForeignKey("Usuario")]
        public int ID_UserF { get; set; }

        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public string RutaArchivo { get; set; }
        public DateTime FechaComentario { get; set; }

        // Opcionalmente, puedes agregar propiedades de navegación para establecer la relación con la clase Usuario
        public Usuario Usuario { get; set; }
    }
}
