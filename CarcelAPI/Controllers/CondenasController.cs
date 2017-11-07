using CarcelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CarcelAPI.Controllers
{
    public class CondenasController : ApiController
    {
        private CarcelDBContext context;

        public CondenasController()
        {
            context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Condenas.Select(c => new
            {
                Id = c.ID,
                FechaInicioCondena = c.FechaInicioCondena,
                FechaCondena = c.FechaCondena,
                Preso = new
                {
                    NombrePreso = c.Preso.Nombre
                },
                Delitos = new
                {
                    c.Delitos
                }
            });
        }

        public IHttpActionResult post(Condena condena)
        {
            context.Condenas.Add(condena);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }

            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Condena condena = context.Condenas.Find(id);

            if (condena == null) return NotFound();

            context.Condenas.Remove(condena);

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Eliminado Correctamente" });
            }

            return InternalServerError();
        }

        public IHttpActionResult put(Condena condena)
        {
            context.Entry(condena).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Modificado Correctamente" });
            }

            return InternalServerError();
        }
    }
}