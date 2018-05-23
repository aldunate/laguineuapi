using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;


namespace LaGuineuService.Services
{
    public class EscuelaService : IEscuelaService
    {
        
        private LaGuineuEntities db = new LaGuineuEntities();

        public EscuelaModel EditarEscuela(EscuelaModel escuela)
        {
            
            if(escuela.Operacion == "Escuela")
            {
                Escuela auxE = db.Escuela.Find(escuela.Escuela.Id);
                auxE.Nombre = escuela.Escuela.Nombre;
                auxE.Telefono = escuela.Escuela.Telefono;
                auxE.FotoPerfil = escuela.Escuela.FotoPerfil;
                db.SaveChanges();
            }

            if (escuela.Operacion == "Estaciones") 
            {
                db.EscuelaEstacion.RemoveRange(db.EscuelaEstacion.Where(x => x.IdEscuela == escuela.Escuela.Id));
                db.SaveChanges();
                escuela.EstacionesDisponibles.ForEach(ee =>
               {
                   db.EscuelaEstacion.Add(new EscuelaEstacion { IdEstacion = ee.IdEstacion, IdEscuela = escuela.Escuela.Id });
               });
                db.SaveChanges();
            }
            if (escuela.Operacion == "Disponibles")
            {
                db.EscuelaDisponible.RemoveRange(db.EscuelaDisponible.Where(x => x.IdEscuela == escuela.Escuela.Id));
                db.EscuelaDisponible.AddRange(escuela.FechasDisponibles);
                db.SaveChanges();
            }

            if (escuela.Operacion == "Deportes")
            {
                db.EscuelaDeporte.RemoveRange(db.EscuelaDeporte.Where(x => x.IdEscuela == escuela.Escuela.Id));
                db.EscuelaDeporte.AddRange(escuela.DeportesDisponibles);
                db.SaveChanges();
            }
            return escuela;
        }

        public EscuelaModel GetEscuela(int id)
        {
            EscuelaModel escuela = new EscuelaModel();
            escuela.Escuela = db.Escuela.Find(id);
            // Esta deberia quitarla 
            escuela.FechasDisponibles = db.EscuelaDisponible.Where(x => x.IdEscuela == id).ToList();
            escuela.DeportesDisponibles = db.EscuelaDeporte.Where(x => x.IdEscuela == id).ToList();
            escuela.EstacionesDisponibles = (from ee in db.EscuelaEstacion
                              join es in db.Estacion on  ee.IdEstacion equals es.Id
                              where ee.IdEscuela == id 
                              select new EscuelaEsModel
                              {
                                  Id = es.Id,
                                  Nombre = es.Name
                              }).ToList();
            return escuela;

        }

        public int GuardarPerfil(int idEscuela, string fotoPerfil)
        {
            Escuela escuela = db.Escuela.Find(idEscuela);
            escuela.FotoPerfil = fotoPerfil;
            db.SaveChanges();
            return idEscuela;
        }

        
    }
}




















































































































































































































