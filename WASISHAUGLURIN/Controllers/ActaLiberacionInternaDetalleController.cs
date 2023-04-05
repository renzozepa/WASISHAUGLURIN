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
    public class ActaLiberacionInternaDetalleController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ActaLiberacionInternaDetalle
        public IQueryable<ActaLiberacionInternaDetalle> GetActaLiberacionInternaDetalle()
        {
            return db.ActaLiberacionInternaDetalle;
        }

        // GET: api/ActaLiberacionInternaDetalle/5
        [ResponseType(typeof(ActaLiberacionInternaDetalle))]
        public IHttpActionResult GetActaLiberacionInternaDetalle(int id)
        {
            ActaLiberacionInternaDetalle actaLiberacionInternaDetalle = db.ActaLiberacionInternaDetalle.Find(id);
            if (actaLiberacionInternaDetalle == null)
            {
                return NotFound();
            }

            return Ok(actaLiberacionInternaDetalle);
        }

        // PUT: api/ActaLiberacionInternaDetalle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActaLiberacionInternaDetalle(int id, ActaLiberacionInternaDetalle actaLiberacionInternaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actaLiberacionInternaDetalle.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(actaLiberacionInternaDetalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaLiberacionInternaDetalleExists(id))
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

        // POST: api/ActaLiberacionInternaDetalle
        [ResponseType(typeof(ActaLiberacionInternaDetalle))]
        public IHttpActionResult PostActaLiberacionInternaDetalle(ActaLiberacionInternaDetalle actaLiberacionInternaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActaLiberacionInternaDetalle.Add(actaLiberacionInternaDetalle);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActaLiberacionInternaDetalleExists(actaLiberacionInternaDetalle.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = actaLiberacionInternaDetalle.CodProyecto }, actaLiberacionInternaDetalle);
        }

        // DELETE: api/ActaLiberacionInternaDetalle/5
        [ResponseType(typeof(ActaLiberacionInternaDetalle))]
        public IHttpActionResult DeleteActaLiberacionInternaDetalle(int id)
        {
            ActaLiberacionInternaDetalle actaLiberacionInternaDetalle = db.ActaLiberacionInternaDetalle.Find(id);
            if (actaLiberacionInternaDetalle == null)
            {
                return NotFound();
            }

            db.ActaLiberacionInternaDetalle.Remove(actaLiberacionInternaDetalle);
            db.SaveChanges();

            return Ok(actaLiberacionInternaDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActaLiberacionInternaDetalleExists(int id)
        {
            return db.ActaLiberacionInternaDetalle.Count(e => e.CodProyecto == id) > 0;
        }
    }
}