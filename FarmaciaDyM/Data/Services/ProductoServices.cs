using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public class Result
    {
        public bool Succes { get; set; }
        public string message { get; set; }

    }
    public class Result<T>
    {
        public bool Succes { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

    }


    public class ProductoServices : IProductoServices

    {
        private readonly IMyDbContext dbContext;

        public ProductoServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(ProductosRequest request)
        {
            try
            {
                var producto = Producto.crear(request);

                dbContext.Productos.Add(producto);
                await dbContext.SaveChangesAsync();
                return new Result() { message = "OK", Succes = true };

            }

            catch (Exception E)
            {

                return new Result() { message= E.Message, Succes = false };
            }

        }
        public async Task<Result> MOdificar(ProductosRequest request)
        {
            try
            {
                var Producto = await dbContext.Productos.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (Producto == null)
                    return new Result() { message = "No se Encontro El Producto", Succes = false };
                if (Producto.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { message = "OK", Succes = true };




            }

            catch (Exception E)
            {

                return new Result() { message = E.Message, Succes = false };
            }
        }
        public async Task<Result> Eliminar(ProductosRequest request)
        {
            try
            {
                var Producto = await dbContext.Productos.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (Producto == null)
                    return new Result() { message = "No se Encontro El Producto", Succes = false };
                dbContext.Productos.Remove(Producto);
                await dbContext.SaveChangesAsync();
                return new Result() { message = "OK", Succes = true };


            }

            catch (Exception E)
            {

                return new Result() { message= E.Message, Succes = false };
            }

        }
        public async Task<Result> Modificar(ProductosRequest request)
        {
            try
            {
                var Producto = await dbContext.Productos.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (Producto == null)
                    return new Result() { message= "No se Encontro El Producto", Succes = false };
                if (Producto.Modificar(request))
                    await dbContext.SaveChangesAsync();
                return new Result() { message = "OK", Succes = true };




            }

            catch (Exception E)
            {

                return new Result() { message = E.Message, Succes = false };
            }

        }
        public async Task<Result<List<ProductoResponse>>> Consultar(string Filtro)
        {
            try
            {
                var producto = await dbContext.Productos.Where(c =>

                (c.Nombre + "" + c.Codigo + " " + c.Nombre)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<ProductoResponse>>()
                {
                    Message= "OK",
                    Succes = true,
                    Data = producto
                };
            }

            catch (Exception E)
            {

                return new Result<List<ProductoResponse>>()
                {
                    Message = E.Message,
                    Succes= false,
                };


            }

        }

    }

}


