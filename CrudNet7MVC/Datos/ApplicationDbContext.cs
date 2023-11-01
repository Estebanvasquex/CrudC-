using CrudNet7MVC.Models;
using Microsoft.EntityFrameworkCore;
 
namespace CrudNet7MVC.Datos
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        //ARCHIVO DE CONTEXTO, AQUÍ SE AGREGAN LOS MODELOS QUE SERAN NUESTRAS TABLAS
        public DbSet<Contacto> Contacto { get; set; }
    
    }
}
