using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EstacionController : ApiController
    {
        // Curso
        private IEstacionService estacionService = new EstacionService();

        public List<Estacion> Get()
        {
            return estacionService.GetEstaciones();
        }

        // No se trabaja con idEscuela
        public List<EscuelaEstacion> GetEstacionEscuela(int cualquiera)
        {
            Token token = (Token)Request.Properties["token"];
            return estacionService.GetEstacionEscuela(token.IdEscuela);
        }

        public async Task<Object> GetEstacionTiempo(string lat, string lon)
        {
            // Documentacion https://opendata.aemet.es/dist/index.html?

            /* doc  ski resort weather https://openweathermap.org/appid  API KEY a0a8b66ccbd71d769f07d8424f400e19
            Example of API call
            api.openweathermap.org / data / 2.5 / weather ? q = London,uk & APPID = a0a8b66ccbd71d769f07d8424f400e19
            API documentation
            http://openweathermap.org/api

            La molina
            api.openweathermap.org/data/2.5/forecast?lat=42.3371300&lon=1.9413600&APPID=a0a8b66ccbd71d769f07d8424f400e19
            Longitud: 1.9413600
            Latitud: 42.3371300

            3002158	Les Angles	43.958061	4.763420	FR


            */

            // Crear objeto. Utiliza el reloj del sistema para crear una semilla.
            Random rnd = new Random();
            lon = rnd.Next(1, 100).ToString();
            lon = rnd.Next(1, 100).ToString();

            try
            {
                HttpClient client = new HttpClient();
                string apikey = "a0a8b66ccbd71d769f07d8424f400e19";
                client.DefaultRequestHeaders.TryAddWithoutValidation("accept-encoding", "Accepflate, sdch");
                client.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");
                // client.DefaultRequestHeaders.TryAddWithoutValidation("origin", "http://api.openweathermap.org");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("http://api.openweathermap.org/data/2.5/forecast?lat=" + lat+"&lon="+lon+"&APPID="+ apikey);
                return await response.Content.ReadAsAsync<Object>();
            }
            catch (Exception e)
            {
                return e;
            }
        }

    }
}