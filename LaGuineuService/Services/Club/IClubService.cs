using LaGuineuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaGuineuService.Services
{ 
    public interface IClubService
    {
        Club GetClub(int idEscuela);
        List<Club> GetClubesEscuela(int idEscuela);
        int PostClub(ClubModel club);

    }
}