using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;


namespace LaGuineuService.Services
{
    public class ClubService : IClubService
    {
        
        private LaGuineuEntities db = new LaGuineuEntities();

        public Club GetClub(int id)
        {
            Club club = db.Club.Find(id);
            return club;
        }

        public List<Club> GetClubesEscuela(int idEscuela)
        {
            return db.Club.Where(x => x.IdEscuela == idEscuela).ToList();
        }

        public int PostClub(ClubModel club)
        {

            return 0;
        }

    }
}




















































































































































































































