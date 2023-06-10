using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IClienteServicescs
    {
        Task<Result<List<ClienteResponse>>> Consultar(string Filtro);
        Task<Result> Crear(ClientesRequest request);
        Task<Result> Eliminar(ClientesRequest request);
        Task<Result> Modificar(ClientesRequest request);
    }
}