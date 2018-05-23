using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MonitorController : ApiController
    {

        public IMonitorService monitorService = new MonitorService();
        public ITokenService tokenService = new TokenService();

        // GET: Monitor
        public Object Get(int id)
        {
            return monitorService.GetMonitor(id);
        }

        public List<Monitor> GetMonitores()
        {
            Token token = (Token) Request.Properties["token"];
            return monitorService.GetMonitorEscuela(token.IdEscuela);
        }

        public MonitorModel Post(MonitorModel monitor) // List<MonitorTitulo> titulos
        {
            Token token = (Token)Request.Properties["token"];
            monitor.Monitor.IdEscuela = token.IdEscuela;
            return monitorService.EditarMonitor(monitor);
        }


    }
}