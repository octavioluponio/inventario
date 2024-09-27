using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace luponio_madereras.Models
{
    public class Producto
    {
        [Key]
        public int idproducto { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public int idcategoria { get; set; }
        public int idproveedor { get; set; }

        [ForeignKey("idcategoria")]
        public Categoria? Categoria { get; set; }

        [ForeignKey("idproveedor")]
        public Proveedor? Proveedor { get; set; }
    }
}
