using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ClubController : ApiController
    {

        public IClubService clubService = new ClubService();
        public IUsuarioService usuarioService = new UsuarioService();
        
        // GET: Monitor
        public List<Club> GetClubesEscuela()
        {
            Token token = (Token)Request.Properties["token"];
            return clubService.GetClubesEscuela(token.IdEscuela);
        }

    }
}