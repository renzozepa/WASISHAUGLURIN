using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using AppCalidad.Tablas;
using System.Threading;
using System.IO;
using System.Net.Http.Headers;

namespace AppCalidad.ServicioApi
{
    public class HaugApi
    {
        public static HaugApi Metodo = new HaugApi();
        public const string urlapi = "http://ti.haug.com.pe/WACalidad";
        public async Task<List<Usuarios>> GetAllUsuario()
        {
            List<Usuarios> LstTask = new List<Usuarios>();
            try
            {
                HttpClient client = new HttpClient
                {
                    MaxResponseContentBufferSize = 256000
                };
                var uri = new Uri(urlapi);
                var response = await client.GetAsync(uri + "/Api/Usuario", HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LstTask = JsonConvert.DeserializeObject<List<Usuarios>>(content);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return LstTask;
        }
        public async Task<List<Proyectos>> GetAllProyectos()
        {
            List<Proyectos> LstTask = new List<Proyectos>();
            try
            {
                HttpClient client = new HttpClient
                {
                    MaxResponseContentBufferSize = 256000
                };
                var uri = new Uri(urlapi);
                var response = await client.GetAsync(uri + "/Api/Proyecto", HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LstTask = JsonConvert.DeserializeObject<List<Proyectos>>(content);
                }
            }
            catch (Exception ex)
            {
                string rpt = ex.Message.ToString();
                throw;
            }
            return LstTask;
        }
        public async Task<List<ProyectoPeriodo>> GetAllProyectoPeriodos(string proyecto)
        {
            List<ProyectoPeriodo> LstTask = new List<ProyectoPeriodo>();
            try
            {
                HttpClient client = new HttpClient
                {
                    MaxResponseContentBufferSize = 256000
                };
                var uri = new Uri(urlapi);
                var response = await client.GetAsync(uri + "/Api/ProyectoPeriodoCalendario?Proyecto=" + proyecto, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LstTask = JsonConvert.DeserializeObject<List<ProyectoPeriodo>>(content);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return LstTask;
        }
        public async Task<List<ProyectoElemento>> GetAllProyectoElemento(string proyecto)
        {
            List<ProyectoElemento> LstTask = new List<ProyectoElemento>();
            try
            {
                HttpClient client = new HttpClient
                {
                    MaxResponseContentBufferSize = 256000
                };
                var uri = new Uri(urlapi);
                var response = await client.GetAsync(uri + "/Api/ProyectoElemento?proyecto=" + proyecto, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LstTask = JsonConvert.DeserializeObject<List<ProyectoElemento>>(content);
                }
            }
            catch (Exception ex)
            {
                string var = ex.Message;
                throw;
            }
            return LstTask;
        }
    }
}
