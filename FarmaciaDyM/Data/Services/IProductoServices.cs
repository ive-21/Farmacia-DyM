using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IProductoServices
    {
        Task<Result<List<ProductoResponse>>> Consultar(string Filtro);
        Task<Resultados> Crear(ProductosRequest request);
        Task<Resultados> Eliminar(ProductosRequest request);
        Task<Resultados> Modificar(ProductosRequest request);
    }
}