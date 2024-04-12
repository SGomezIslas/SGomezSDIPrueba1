using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> Add(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", exepcion } };

            try
            {
                using (DL.SGomezSDIPrueba1Entities context = new DL.SGomezSDIPrueba1Entities())
                {
                    int filasAfectadas = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Edad);

                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {

                    }
                }
            }catch (Exception ex) 
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", exepcion }, { "Usuario", usuario } };
            try
            {
                using (DL.SGomezSDIPrueba1Entities context = new DL.SGomezSDIPrueba1Entities())
                {
                    var registros = context.UsuarioGetAll().ToList();

                    if( registros != null )
                    {
                        usuario.Usuarios = new List<object>();
                        foreach( var registro in registros )
                        {
                            ML.Usuario user = new ML.Usuario();

                            user.IdUsuario = registro.IdUsuario;
                            user.Nombre = registro.Nombre;
                            user.ApellidoPaterno = registro.ApellidoPaterno;
                            user.ApellidoMaterno = registro.ApellidoMaterno;
                            user.Edad = (int)registro.Edad;

                            usuario.Usuarios.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {

                    }
                }
            }catch(Exception ex) 
            {
                diccionario["Excepcion"] = ex.Message;
                diccionario["Resultado"] = false;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Update(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL.SGomezSDIPrueba1Entities context = new DL.SGomezSDIPrueba1Entities())
                {
                    int filasAfectadas = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Edad);
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetById(int IdUsuario)
        {
            ML.Usuario usuario= new ML.Usuario();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", usuario }, { "Resultado", false }, { "Excepcion", exepcion } };

            try
            {
                using (DL.SGomezSDIPrueba1Entities context = new DL.SGomezSDIPrueba1Entities())
                {
                    var registro = context.UsuarioGetById(IdUsuario).SingleOrDefault();
                    if (registro != null)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> Delete(int IdUsuaro)
        {
            ML.Usuario usuario = new ML.Usuario();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Excepcion", exepcion }, { "Resultado", false }, { "Usuario", usuario } };

            try
            {
                using (DL.SGomezSDIPrueba1Entities context = new DL.SGomezSDIPrueba1Entities())
                {
                    int filasAfectadas = context.UsuarioDelete(IdUsuaro);
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
    }
}
