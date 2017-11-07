using CarcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CarcelAPI.Controllers
{
    public class DelitosController : ApiController
    {
        private CarcelDBContext context;

        public DelitosController()
        {
            context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Delitos.ToList();
        }

        public IHttpActionResult post(Delito delito)
        {
            context.Delitos.Add(delito);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }

            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Delito delito = context.Delitos.Find(id);

            if (delito == null) return NotFound();

            context.Delitos.Remove(delito);

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Eliminado Correctamente" });
            }

            return InternalServerError();
        }

        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Modificado Correctamente" });
            }

            return InternalServerError();
        }
    }
}