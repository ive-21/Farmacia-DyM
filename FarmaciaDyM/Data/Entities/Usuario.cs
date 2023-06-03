﻿using FarmaciaDyM.Data.Request;
using FarmaciaDyM.Data.Response;
using System.Collections.Generic;

namespace FarmaciaDyM.Data.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string CorreoElectronico { get; set; }
        public string Clave { get; set; }

        public static Usuario crear(UsuariosRequest usuarios)
       => new Usuario()
       {
           Nombre = usuarios.Nombre,
           Rol = usuarios.Rol,
           CorreoElectronico = usuarios.CorreoElectronico,
           Clave = usuarios.Clave,

       };
        public bool Modificar(UsuariosRequest usuarios)
        {
            var cambio = false;
            if (Nombre != usuarios.Nombre)
            {
                Nombre = usuarios.Nombre;
                cambio = true;
            }
            if (Rol != usuarios.Rol)
            {
                Rol = usuarios.Rol;
                cambio = true;
            }
            if (CorreoElectronico != usuarios.CorreoElectronico)
            {
                CorreoElectronico = usuarios.CorreoElectronico;
                cambio = true;
            }

            return cambio;
        }


        public ClienteResponse ToResponse()
          => new ClienteResponse()
          {
              
          };
    }



    
    


    

    

  
    }




