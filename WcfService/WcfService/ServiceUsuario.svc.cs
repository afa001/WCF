using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.Model;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuario.svc o ServiceUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuario : IServiceUsuario
    {
        //With Stop Procedures - EntityFramework
        public bool create(Usuario usuario)
        {
            using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
            {
                try
                {
                    var user = cs.InsertUsuario(usuario.Nombre, usuario.FechaNacimiento, usuario.Sexo);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public bool delete(Usuario usuario)
        {
            using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
            {
                //sp
                var usuarios = cs.DeleteUsuario(usuario.Id);
                return true;
            };
        }

        public bool edit(Usuario usuario)
        {
            using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
            {
                //sp
                cs.UpdateUsuario(usuario.Id,usuario.Nombre,usuario.FechaNacimiento,usuario.Sexo);
                return true;
            };
        }

        public List<GetUsuario_Result> findall()
        {
            using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
            {
                //sp
                var usuarios = cs.GetUsuario().ToList();
                return usuarios;
            };
        }

        public Usuario find(string id)
        {
            using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
            {
                //sp
                int nId = Convert.ToInt32(id);
                var usuario = new Usuario();
                usuario = cs.Usuario.Find(nId);

                return usuario;
            };
        }

        //With EntityFramework
        //public bool create(Usuario usuario)
        //{
        //    using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
        //    {
        //        try
        //        {
        //            Usuario user = new Usuario();
        //            user.Nombre = usuario.Nombre;
        //            user.FechaNacimiento = usuario.FechaNacimiento;
        //            user.Sexo = usuario.Sexo;

        //            cs.Usuario.Add(user);
        //            cs.SaveChanges();

        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    };
        //}

        //public bool delete(Usuario usuario)
        //{
        //    using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
        //    {
        //        try
        //        {
        //            Usuario user = cs.Usuario.Single(u => u.Id == usuario.Id);
        //            cs.Usuario.Remove(user);
        //            cs.SaveChanges();

        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    };
        //}

        //public bool edit(Usuario usuario)
        //{
        //    using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
        //    {
        //        try
        //        {
        //            Usuario user = cs.Usuario.Single(u => u.Id == usuario.Id);
        //            user.Nombre = usuario.Nombre;
        //            user.FechaNacimiento = usuario.FechaNacimiento;
        //            user.Sexo = usuario.Sexo;

        //            cs.SaveChanges();

        //            return true;
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    };
        //}


        //public List<Usuario> findall()
        //{
        //    using (bdComponenteServiExEntities cs =new bdComponenteServiExEntities()) {

        //        var producto = from p in cs.Usuario select p;
        //        return producto.ToList();
        //    };
        //}

        //public Usuario find(string id)
        //{
        //    using (bdComponenteServiExEntities cs = new bdComponenteServiExEntities())
        //    {
        //        int nId = Convert.ToInt32(id);
        //        var usuario = new Usuario();
        //            usuario = cs.Usuario.Find(nId);

        //        return usuario;
        //    };
        //}
    }
}
