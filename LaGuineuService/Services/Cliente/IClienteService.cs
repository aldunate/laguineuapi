using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGuineuService.Services
{ 
    public interface IClienteService
    {
        int PostCliente(ClienteModel escuela);
        Cliente GetCliente(int id);
        List<Cliente> GetClientesEscuela(int idEscuela);
    }
}