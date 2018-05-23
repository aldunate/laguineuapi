using System.Collections.Generic;
using System.Web.Http;
using LaGuineuData;
using LaGuineuService.Services;
using System.Web.Http.Cors;
using System;

namespace LaGuineuApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ClienteController : ApiController
    {

        public IClienteService clienteService = new ClienteService();
        public IUsuarioService usuarioService = new UsuarioService();
        
        // GET: Monitor
        public Object GetCliente(int id)
        {
            return clienteService.GetCliente(id);
        }

        public Object GetClientesEscuela()
        {
            Token token = (Token)Request.Properties["token"];
            return clienteService.GetClientesEscuela(token.IdEscuela);
        }

        public int Post(ClienteModel cliente)
        {
            Token token = (Token)Request.Properties["token"];
            cliente.Cliente.IdEscuela = token.IdEscuela;
            cliente.Usuario.IdEscuela = token.IdEscuela;
            return clienteService.PostCliente(cliente);
        }


    }
}