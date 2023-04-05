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
    public class ProyectoEnsambleController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ProyectoEnsamble
        public IQueryable<ProyectoEnsamble> GetProyectoEnsamble()
        {
            return db.ProyectoEnsamble;
        }

        // GET: api/ProyectoEnsamble/5
        [ResponseType(typeof(ProyectoEnsamble))]
        public IHttpActionResult GetProyectoEnsamble(int id)
        {
            ProyectoEnsamble proyectoEnsamble = db.ProyectoEnsamble.Find(id);
            if (proyectoEnsamble == null)
            {
                return NotFound();
            }

            return Ok(proyectoEnsamble);
        }

        // PUT: api/ProyectoEnsamble/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyectoEnsamble(int id, ProyectoEnsamble proyectoEnsamble)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectoEnsamble.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(proyectoEnsamble).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoEnsambleExists(id))
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

        // POST: api/ProyectoEnsamble
        [ResponseType(typeof(ProyectoEnsamble))]
        public IHttpActionResult PostProyectoEnsamble(ProyectoEnsamble proyectoEnsamble)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProyectoEnsamble.Add(proyectoEnsamble);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyectoEnsambleExists(proyectoEnsamble.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proyectoEnsamble.CodProyecto }, proyectoEnsamble);
        }

        // DELETE: api/ProyectoEnsamble/5
        [ResponseType(typeof(ProyectoEnsamble))]
        public IHttpActionResult DeleteProyectoEnsamble(int id)
        {
            ProyectoEnsamble proyectoEnsamble = db.ProyectoEnsamble.Find(id);
            if (proyectoEnsamble == null)
            {
                return NotFound();
            }

            db.ProyectoEnsamble.Remove(proyectoEnsamble);
            db.SaveChanges();

            return Ok(proyectoEnsamble);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyectoEnsambleExists(int id)
        {
            return db.ProyectoEnsamble.Count(e => e.CodProyecto == id) > 0;
        }
    }
}