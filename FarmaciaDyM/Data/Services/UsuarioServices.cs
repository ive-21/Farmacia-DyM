using FarmaciaDyM.Data.Context;
using FarmaciaDyM.Data.Entities;
using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaDyM.Data.Services
{
    public class Resultt
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class Resultt<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }


    public class UsuarioServices : IUsuarioServices
    {
        private readonly IMyDbContext dbContext;

        public UsuarioServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Resultt> Crear(UsuariosRequest request)
        {
            try
            {
                var usuario = Usuario.crear(request);

                dbContext.Usuarios.Add(usuario);
                await dbContext.SaveChangesAsync();
                return new Resultt() { Message = "OK", Success = true };




            }

            catch (Exception E)
            {

                return new Resultt() { Message = E.Message, Success = false };
            }

        }
        public async Task<Resultt> MOdificar(UsuariosRequest request)
        {
            try
            {
                var Usuario = await dbContext.Usuarios.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (Usuario == null)
                    return new Resultt() { Message = "No se Encontro El Usuario", Success = false };
                if (Usuario.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Resultt() { Message = "OK", Success = true };




            }

            catch (Exception E)
            {

                return new Resultt() { Message = E.Message, Success = false };
            }

        }
        public async Task<Resultt> Eliminar(UsuariosRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (usuario == null)
                    return new Resultt() { Message = "No se Encontro El Cliente", Success = false };
                dbContext.Usuarios.Remove(usuario);
                await dbContext.SaveChangesAsync();
                return new Resultt() { Message = "OK", Success = true };




            }

            catch (Exception E)
            {

                return new Resultt() { Message = E.Message, Success = false };
            }
        }
        public async Task<Resultt<List<UsuariosResponse>>> Consultar(string Filtro)
        {
            try
            {
                var Usuario = await dbContext.Usuarios.Where(c =>

               (c.Nombre + "" + c.Rol + " " + c.CorreoElectronico
               )
               .ToLower()
               .Contains(Filtro.ToLower()
               )
               )
               .Select(c => c.ToResponse())
               .ToListAsync();
                return new Resultt<List<UsuariosResponse>>()
                {
                    Message = "OK",
                    Success = true,
                    Data = Usuario
                };
            }

            catch (Exception E)
            {

                return new Resultt<List<UsuariosResponse>>()
                {
                    Message = E.Message,
                    Success = false,
                };
            }

        }
    }
}

