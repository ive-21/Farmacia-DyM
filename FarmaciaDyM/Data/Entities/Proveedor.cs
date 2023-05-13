using System.ComponentModel.DataAnnotations;

namespace FarmaciaDyM.Data.Entities
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }

}

