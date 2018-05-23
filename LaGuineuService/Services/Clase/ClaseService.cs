using System;
using System.Collections.Generic;
using System.Linq;
using LaGuineuData;


namespace LaGuineuService.Services
{
    public class ClaseService : IClaseService
    {
        private LaGuineuEntities db = new LaGuineuEntities();

        public Clase GetClase(int id)
        {
            return db.Clase.Find(id);
        }



        public List<Clase> GetClaseEscuela(int idEscuela)
        {
            return db.Clase.Where(x => x.IdEscuela == idEscuela).ToList();
        }

        public List<ClaseModel> GetClaseEscuelaFecha(int idEscuela, string fecha)
        {
            var aux = fecha.Split('/');
            var fec = new DateTime(int.Parse(aux[2]), int.Parse(aux[1]), int.Parse(aux[0]));
            var clasesList = db.Clase.Where(x => x.IdEscuela == idEscuela && x.Fecha == fec).ToList();
            var clases = new List<ClaseModel>{ };
            clasesList.ForEach(clase =>
            {
                var c = new ClaseModel { };
                c.Clase = clase;
                c.Monitores = new List<ClaseMonitor>();
                c.Clientes = new List<ClaseCliente>();
                var claseMonitor = db.ClaseMonitor.Where(x => x.IdClase == clase.Id).ToList();
                claseMonitor.ForEach(cm =>
               {
                   c.Monitores.Add(cm);
               });
                clases.Add(c);
            });
            return clases;
        }

        public int PostAsignada(ClaseModel asignada)
        {
            Clase c = db.Clase.Find(asignada.Clase.Id);
            c.HoraInicio = asignada.Clase.HoraInicio;
            c.HoraFin = asignada.Clase.HoraFin;
            c.IdEstacion = asignada.Clase.IdEstacion;
            db.SaveChanges();
            var claseMontior = db.ClaseMonitor.Where(x => 
                x.IdClase == asignada.Clase.Id
            ).ToList();
            db.ClaseMonitor.RemoveRange(claseMontior);
            db.ClaseMonitor.AddRange(asignada.Monitores);
            db.SaveChanges();
            return asignada.Clase.Id;
        }

        public Clase PostClase(Clase clase)
        {
            db.Clase.Add(clase);
            db.SaveChanges();
            return clase;
        }

    }
}


