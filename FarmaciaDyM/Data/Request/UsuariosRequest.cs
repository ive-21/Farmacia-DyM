using FarmaciaDyM.Data.Entities;

namespace FarmaciaDyM.Data.Request
{
    public class UsuariosRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string CorreoElectronico { get; set; }
        public string Clave { get; set; }


    }
}
