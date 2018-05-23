﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;


namespace LaGuineuService.Services
{
    public class UtilService : IUtilService
    {
        
        private LaGuineuEntities db = new LaGuineuEntities();

        public List<Nivel> GetNiveles()
        {
            return db.Nivel.ToList();
        }

        public List<Titulo> GetTitulos()
        {
            return db.Titulo.ToList();
        }
    }
}




















































































































































































































