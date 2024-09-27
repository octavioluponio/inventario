using System.ComponentModel.DataAnnotations;

namespace luponio_madereras.Models
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int idroles { get; set; }
    }
}
