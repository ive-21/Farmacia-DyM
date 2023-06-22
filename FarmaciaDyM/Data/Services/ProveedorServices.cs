using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public class Resultaaa
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }


    public class Resulttt<T>
    {

        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data;
        }


    public class ProveedorServices : IProveedorServices
    {
        private readonly IMyDbContext dbContext;

        public ProveedorServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Resultando> Crear(ProveedorRequest request)
        {
            try
            {

                var proveedor = Proveedor.crear(request);

                dbContext.Proveedores.Add(proveedor);
                await dbContext.SaveChangesAsync();
                return new Result() { Message= "OK", Success= true };

            }

            catch (Exception E)
            {

                return new Result() { message = E.Message, Succes = false };
            }




        }
        public async Task<Resultt> Modificar(ProveedorRequest request)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (proveedor == null)
                    return new Resultt() { Message = "No se Encontro El Proveedor", Success = false };
                if (proveedor.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Resultt() { Message = "OK", Success = true };




            }

            catch (Exception E)
            {

                return new Resultt() { Message = E.Message, Success = false };
            }

        }
        public async Task<Resultt> Eliminar(ProveedorRequest request)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (proveedor == null)
                    return new Resultt() { Message = "No se Encontro El Producto", Success = false };
                dbContext.Proveedores.Remove(proveedor);
                await dbContext.SaveChangesAsync();
                return new Resultt() { Message = "OK", Success = true };


            }

            catch (Exception E)
            {

                return new Resultt() { Message = E.Message, Success = false };
            }





        }
        public async Task<Result<List<ProveedorResponse>>> Consultar(string Filtro)
        {
            try
            {
                var proveedor = await dbContext.Proveedores.Where(c =>

                (c.Nombre + "" + c.Id + " " + c.Nombre)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<ProveedorResponse>>()
                {
                    Message = "OK",
                    Succes = true,
                    Data = proveedor
                };
            }

            catch (Exception E)
            {

            



                return new Result<List<ProveedorResponse>>()
                {
                    Message = E.Message,
                    Succes = false,
                };

            }
        }
    }
}