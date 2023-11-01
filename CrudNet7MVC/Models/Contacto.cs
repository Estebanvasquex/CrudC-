using System.ComponentModel.DataAnnotations;

namespace CrudNet7MVC.Models
{
    public class Contacto
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "El id es obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string telefono { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string celular { get; set; }
        [Required(ErrorMessage = "El celular es obligatorio")]
        public string email { get; set; }
        public DateTime fechaCreacion { get; set; }

    }
}
