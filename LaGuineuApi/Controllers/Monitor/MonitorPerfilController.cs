using Newtonsoft.Json.Linq;
using System.Web.Http;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using LaGuineuApi.Util.lib;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MonitorPerfilController : ApiController
    {
        public IMonitorService monitorService = new MonitorService();
 
        public HttpResponseMessage Get(string strFileUrl)
        {
            return FileUtil.Download("MonitorPerfil/" + strFileUrl, "Imagen");
        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync()
        {
            HttpResponseMessage json = await FileUtil.Upload(Request,HttpContext.Current, "~/App_Data/Imagenes/MonitorPerfil");
            JObject jObject = JObject.Parse(json.Content.ReadAsStringAsync().Result);
            var fileName = jObject.GetValue("fileName").ToString();
            var idMonitor = int.Parse(jObject.GetValue("idMonitor").ToString());
            monitorService.GuardarPerfil(idMonitor, fileName);
            return json;

        }
    }
}


