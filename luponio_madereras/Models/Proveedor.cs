using System.ComponentModel.DataAnnotations;

namespace luponio_madereras.Models
{
    public class Proveedor
    {
        [Key]
        public int idproveedor { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public ICollection<Producto> Productos { get; set; }

    }
}
