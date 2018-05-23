using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using LaGuineuApi.Util.lib;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EscuelaPerfilController : ApiController
    {
        public IEscuelaService escuelaService = new EscuelaService();

        public HttpResponseMessage GetImagen(string strFileUrl)
        {
            return FileUtil.Download("EscuelaPerfil/" + strFileUrl, "Imagen");
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync()
        {
            HttpResponseMessage json = await FileUtil.Upload(Request, HttpContext.Current, "~/App_Data/Imagenes/EscuelaPerfil");
            JObject jObject = JObject.Parse(json.Content.ReadAsStringAsync().Result);
            var fileName = jObject.GetValue("fileName").ToString();
            Token token = (Token)Request.Properties["token"];
            escuelaService.GuardarPerfil(token.IdEscuela, fileName);
            return json;
        }
    }
}


