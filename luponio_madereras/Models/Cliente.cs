using System.ComponentModel.DataAnnotations;

namespace luponio_madereras.Models
{
    public class Cliente
    {
        [Key]
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
