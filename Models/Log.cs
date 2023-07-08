using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace AR_JC_ProyectoP2.Models
{
    [Table("logResena")]
    public class Log
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdResenaL { get; set; }
        public DateTime DateTime { get; set; }

    }
}