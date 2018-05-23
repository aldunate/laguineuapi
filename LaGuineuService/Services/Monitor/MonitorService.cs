using System;
using System.Collections.Generic;
using System.Linq;
using LaGuineuData;


namespace LaGuineuService.Services
{
    public class MonitorService : IMonitorService
    {
        private LaGuineuEntities db = new LaGuineuEntities();

        public MonitorModel GetMonitor(int id)
        {
            MonitorModel monitor = new MonitorModel();
            monitor.Monitor = db.Monitor.Find(id);
            monitor.Usuario = db.Usuario.Find(monitor.Monitor.IdUsuario);
            // Clean
            monitor.Usuario.Password = null;
            monitor.Usuario.Id = 0;
            monitor.Usuario.IdEscuela = 0;

            monitor.EstacionesDisponibles = db.MonitorEstacion.Where(x => x.IdMonitor == id).ToList();
            monitor.FechasDisponibles = db.MonitorDisponible.Where(x => x.IdMonitor == id).ToList();
            monitor.Titulos = db.MonitorTitulo.Where(x => x.IdMonitor == id).ToList();
            return monitor;
        }



        public MonitorModel EditarMonitor(MonitorModel monitor)
        {
            if(monitor.Operacion == "Crear")
            {
                monitor.Usuario.IdEscuela = monitor.Monitor.IdEscuela;
                monitor.Usuario.FechaCrea = monitor.Monitor.FechaCrea = DateTime.Now;
                monitor.Usuario = db.Usuario.Add(monitor.Usuario);
                db.SaveChanges();

                monitor.Monitor.IdUsuario = monitor.Usuario.Id;
                db.Monitor.Add(monitor.Monitor);
                db.SaveChanges();

                for (var i = 0; i < monitor.Titulos.Count; i++)
                {
                    monitor.Titulos[i].IdMonitor = monitor.Monitor.Id;
                }
                db.MonitorTitulo.AddRange(monitor.Titulos);
                db.SaveChanges();
                return monitor;
            }
            if (monitor.Operacion == "Monitor")
            {
                Monitor auxM = db.Monitor.Find(monitor.Monitor.Id);
                auxM.Nombre = monitor.Monitor.Nombre;
                auxM.Telefono = monitor.Monitor.Telefono;
                auxM.FotoPerfil = monitor.Monitor.FotoPerfil;
                auxM.Apellidos = monitor.Monitor.Apellidos;
                auxM.FechaNacimiento = monitor.Monitor.FechaNacimiento;
                db.SaveChanges();
                db.MonitorTitulo.RemoveRange(db.MonitorTitulo.Where(x => x.IdMonitor == monitor.Monitor.Id));
                db.SaveChanges();
                for (var i = 0; i < monitor.Titulos.Count; i++)
                {
                    monitor.Titulos[i].IdMonitor = monitor.Monitor.Id;
                }
                db.MonitorTitulo.AddRange(monitor.Titulos);
                db.SaveChanges();
            }

            if (monitor.Operacion == "Estaciones")
            {
                db.MonitorEstacion.RemoveRange(db.MonitorEstacion.Where(x => x.IdMonitor == monitor.Monitor.Id));
                db.SaveChanges();
                db.MonitorEstacion.AddRange(monitor.EstacionesDisponibles);
                db.SaveChanges();
            }
            if (monitor.Operacion == "Disponibles")
            {
                db.MonitorDisponible.RemoveRange(db.MonitorDisponible.Where(x => x.IdMonitor == monitor.Monitor.Id));
                db.MonitorDisponible.AddRange(monitor.FechasDisponibles);
                db.SaveChanges();
            }
            
            return monitor;
        }

        public void PostMonitorDisponible(List<MonitorDisponible> monitorDisponible, int idMonitor)
        {
            db.MonitorDisponible.RemoveRange(db.MonitorDisponible.Where(x => x.IdMonitor == idMonitor));
            db.MonitorDisponible.AddRange(monitorDisponible);
            db.SaveChanges();
        }

        public void PostMonitorEstacion(List<MonitorEstacion> monitorEstacion, int idMonitor)
        {
            db.MonitorEstacion.RemoveRange(db.MonitorEstacion.Where(x => x.IdMonitor == idMonitor));
            db.MonitorEstacion.AddRange(monitorEstacion);
            db.SaveChanges();
        }

        public List<Monitor> GetMonitorEscuela(int idEscuela)
        {
            return db.Monitor.Where(x => x.IdEscuela == idEscuela).ToList();
        }

        int IMonitorService.GuardarPerfil(int idMonitor, string fotoPerfil)
        {
            Monitor monitor = db.Monitor.Find(idMonitor);
            monitor.FotoPerfil = fotoPerfil;
            db.SaveChanges();
            return idMonitor;
        }
    }
}


