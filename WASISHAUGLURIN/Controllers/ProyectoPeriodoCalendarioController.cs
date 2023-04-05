using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WASISHAUGLURIN.Models;

namespace WASISHAUGLURIN.Controllers
{
    public class ProyectoPeriodoCalendarioController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ProyectoPeriodoCalendario/15362
        public IQueryable<ProyectoPeriodoCalendario> GetProyectoPeriodoCalendario(string proyecto)
        {
            return db.ProyectoPeriodoCalendario.Where(ppc => ppc.CodProyecto == proyecto + "001" && ppc.CodPeriodo.ToString().Substring(0,2) == "02" && ppc.CodPeriodo.ToString().Length == 8);
        }

        //// GET: api/ProyectoPeriodoCalendario/5
        //[ResponseType(typeof(ProyectoPeriodoCalendario))]
        //public IHttpActionResult GetProyectoPeriodoCalendario(string id)
        //{
        //    ProyectoPeriodoCalendario proyectoPeriodoCalendario = db.ProyectoPeriodoCalendario.Find(id);
        //    if (proyectoPeriodoCalendario == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(proyectoPeriodoCalendario);
        //}

        // PUT: api/ProyectoPeriodoCalendario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyectoPeriodoCalendario(string id, ProyectoPeriodoCalendario proyectoPeriodoCalendario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectoPeriodoCalendario.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(proyectoPeriodoCalendario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoPeriodoCalendarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProyectoPeriodoCalendario
        [ResponseType(typeof(ProyectoPeriodoCalendario))]
        public IHttpActionResult PostProyectoPeriodoCalendario(ProyectoPeriodoCalendario proyectoPeriodoCalendario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProyectoPeriodoCalendario.Add(proyectoPeriodoCalendario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyectoPeriodoCalendarioExists(proyectoPeriodoCalendario.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proyectoPeriodoCalendario.CodProyecto }, proyectoPeriodoCalendario);
        }

        // DELETE: api/ProyectoPeriodoCalendario/5
        [ResponseType(typeof(ProyectoPeriodoCalendario))]
        public IHttpActionResult DeleteProyectoPeriodoCalendario(string id)
        {
            ProyectoPeriodoCalendario proyectoPeriodoCalendario = db.ProyectoPeriodoCalendario.Find(id);
            if (proyectoPeriodoCalendario == null)
            {
                return NotFound();
            }

            db.ProyectoPeriodoCalendario.Remove(proyectoPeriodoCalendario);
            db.SaveChanges();

            return Ok(proyectoPeriodoCalendario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyectoPeriodoCalendarioExists(string id)
        {
            return db.ProyectoPeriodoCalendario.Count(e => e.CodProyecto == id) > 0;
        }
    }
}