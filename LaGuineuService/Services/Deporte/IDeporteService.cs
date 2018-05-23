using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGuineuService.Services
{ 
    public interface IDeporteService
    {
        List<Deporte> GetDeportes();
        List<Deporte> GetDeportes(int idEscuela);



    }
}