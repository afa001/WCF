using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApplicationClient.Models
{
    public class UsuarioServiceClient
    {
        private string baseUrl = "http://localhost:55937/ServiceUsuario.svc/";

        public List<Usuario> FindAll()
        {
            try
            {
                var webApiClient = new WebClient();
                var json = webApiClient.DownloadString(baseUrl + "findall");
                var js = new JavaScriptSerializer();

                return js.Deserialize<List<Usuario>>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario FindId (string id)
        {
            try
            {
                var usuario = new Usuario();
                var webApiClient = new WebClient();
                string url = string.Format(baseUrl + "find/{0}", id);
                var json = webApiClient.DownloadString(url);
                var js = new JavaScriptSerializer();

                usuario = js.Deserialize<Usuario>(json);
                return usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Create (Usuario usuario)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Usuario));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem,usuario);

                string data = Encoding.UTF8.GetString(mem.ToArray(),0,(int)mem.Length);

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(baseUrl + "create","POST",data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Usuario usuario)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Usuario));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, usuario);

                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(baseUrl + "edit", "PUT", data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete (Usuario usuario)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Usuario));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, usuario);

                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(baseUrl + "delete", "DELETE", data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}