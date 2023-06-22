using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IProveedorServices
    {
        Task<Result<List<ProveedorResponse>>> Consultar(string Filtro);
        Task<Resultando> Crear(ProveedorRequest request);
        Task<Resultt> Eliminar(ProveedorRequest request);
        Task<Resultt> Modificar(ProveedorRequest request);
    }
}