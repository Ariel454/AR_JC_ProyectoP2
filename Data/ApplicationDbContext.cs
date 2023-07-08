using AR_JC_ProyectoP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AR_JC_ProyectoP2.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P08ISPR; Initial Catalog=UsuariosCineflex; Integrated Security=True; TrustServerCertificate=True");
        }
    }
}