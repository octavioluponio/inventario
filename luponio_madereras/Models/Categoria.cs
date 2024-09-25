using System.ComponentModel.DataAnnotations;

namespace luponio_madereras.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
