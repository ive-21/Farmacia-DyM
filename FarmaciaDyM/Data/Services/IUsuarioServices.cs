using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IUsuarioServices
    {
        Task<Resultt<List<UsuariosResponse>>> Consultar(string Filtro);
        Task<Resultt> Crear(UsuariosRequest request);
        Task<Resultt> Eliminar(UsuariosRequest request);
        Task<Resultt> MOdificar(UsuariosRequest request);
    }
}