using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IProveedorServices
    {
        Task<Result<List<ProveedorResponse>>> Consultar(string Filtro);
        Task<Resultados> Crear(ProveedorRequest request);
        Task<Resultados> Eliminar(ProveedorRequest request);
        Task<Resultados> Modificar(ProveedorRequest request);
    }
}