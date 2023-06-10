using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

     
    public class Result<T>
    {

    public bool Success { get; set; }
    public string? Message { get; set; }
        public T? Data;
    }






    public class ClienteServicescs : IClienteServicescs
    {
        private readonly IMyDbContext dbContext;

        public ClienteServicescs(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public async Task<Result> Crear(ClientesRequest request)
        {
            try
            {
                var cliente = Cliente.crear(request);

                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(ClientesRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result() { Message = "No se Encontro El Cliente", Success = false };
                if (cliente.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };




            }

            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }


        }
        public async Task<Result> Eliminar(ClientesRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result() { Message = "No se Encontro El Cliente", Success = false };
                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "OK", Success = true };




            }

            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }

        }
        public async Task<Result<List<ClienteResponse>>> Consultar(string Filtro)
        {
            try
            {
                var clientes = await dbContext.Clientes.Where(c =>

                (c.Nombre + "" + c.Telefono + " " + c.Direccion)
                .ToLower()
                .Contains(Filtro.ToLower()
                )
                )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<ClienteResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = clientes
                };
            }

            catch (Exception E)
            {

                return new Result<List<ClienteResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };
            }
        }
    }
}