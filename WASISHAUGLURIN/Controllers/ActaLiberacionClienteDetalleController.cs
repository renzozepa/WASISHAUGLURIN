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
    public class ActaLiberacionClienteDetalleController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ActaLiberacionClienteDetalle
        public IQueryable<ActaLiberacionClienteDetalle> GetActaLiberacionClienteDetalle()
        {
            return db.ActaLiberacionClienteDetalle;
        }

        // GET: api/ActaLiberacionClienteDetalle/5
        [ResponseType(typeof(ActaLiberacionClienteDetalle))]
        public IHttpActionResult GetActaLiberacionClienteDetalle(int id)
        {
            ActaLiberacionClienteDetalle actaLiberacionClienteDetalle = db.ActaLiberacionClienteDetalle.Find(id);
            if (actaLiberacionClienteDetalle == null)
            {
                return NotFound();
            }

            return Ok(actaLiberacionClienteDetalle);
        }

        // PUT: api/ActaLiberacionClienteDetalle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActaLiberacionClienteDetalle(int id, ActaLiberacionClienteDetalle actaLiberacionClienteDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actaLiberacionClienteDetalle.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(actaLiberacionClienteDetalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaLiberacionClienteDetalleExists(id))
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

        // POST: api/ActaLiberacionClienteDetalle
        [ResponseType(typeof(ActaLiberacionClienteDetalle))]
        public IHttpActionResult PostActaLiberacionClienteDetalle(ActaLiberacionClienteDetalle actaLiberacionClienteDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActaLiberacionClienteDetalle.Add(actaLiberacionClienteDetalle);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActaLiberacionClienteDetalleExists(actaLiberacionClienteDetalle.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = actaLiberacionClienteDetalle.CodProyecto }, actaLiberacionClienteDetalle);
        }

        // DELETE: api/ActaLiberacionClienteDetalle/5
        [ResponseType(typeof(ActaLiberacionClienteDetalle))]
        public IHttpActionResult DeleteActaLiberacionClienteDetalle(int id)
        {
            ActaLiberacionClienteDetalle actaLiberacionClienteDetalle = db.ActaLiberacionClienteDetalle.Find(id);
            if (actaLiberacionClienteDetalle == null)
            {
                return NotFound();
            }

            db.ActaLiberacionClienteDetalle.Remove(actaLiberacionClienteDetalle);
            db.SaveChanges();

            return Ok(actaLiberacionClienteDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActaLiberacionClienteDetalleExists(int id)
        {
            return db.ActaLiberacionClienteDetalle.Count(e => e.CodProyecto == id) > 0;
        }
    }
}