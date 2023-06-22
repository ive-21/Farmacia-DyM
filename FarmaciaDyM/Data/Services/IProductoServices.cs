using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;

namespace FarmaciaDyM.Data.Services
{
    public interface IProductoServices
    {
        Task<Result<List<ProductoResponse>>> Consultar(string Filtro);
        Task<Result> Crear(ProductosRequest request);
        Task<Result> Eliminar(ProductosRequest request);
        Task<Result> Modificar(ProductosRequest request);
    }
}