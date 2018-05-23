using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaGuineuData;


namespace LaGuineuService.Services
{
    public class ClienteService : IClienteService
    {
        
        private LaGuineuEntities db = new LaGuineuEntities();

        public Cliente GetCliente(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            return cliente;
        }

        public List<Cliente> GetClientesEscuela(int idEscuela)
        {
            return db.Cliente.Where(c=> c.IdEscuela == idEscuela).ToList();
        }
        public int PostCliente(ClienteModel cliente)
        {
            if (cliente.Operacion == "Crear")
            {
                cliente.Usuario.IdEscuela = cliente.Cliente.IdEscuela;
                cliente.Usuario.FechaCrea = cliente.Cliente.FechaCrea = DateTime.Now;
                cliente.Usuario = db.Usuario.Add(cliente.Usuario);
                db.SaveChanges();

                cliente.Cliente.IdUsuario = cliente.Usuario.Id;
                db.Cliente.Add(cliente.Cliente);
                db.SaveChanges();
                return cliente.Cliente.Id;
            }
            return 0;
        }
    }
}




















































































































































































































