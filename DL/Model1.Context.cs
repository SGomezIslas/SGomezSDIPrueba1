﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SGomezSDIPrueba1Entities : DbContext
    {
        public SGomezSDIPrueba1Entities()
            : base("name=SGomezSDIPrueba1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual int UsuarioAdd(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> edad)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, edadParameter);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> edad)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, edadParameter);
        }
    }
}