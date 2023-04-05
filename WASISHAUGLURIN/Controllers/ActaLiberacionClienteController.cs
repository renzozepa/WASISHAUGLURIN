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
    public class ActaLiberacionClienteController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ActaLiberacionCliente
        public IQueryable<ActaLiberacionCliente> GetActaLiberacionCliente()
        {
            return db.ActaLiberacionCliente;
        }

        // GET: api/ActaLiberacionCliente/5
        [ResponseType(typeof(ActaLiberacionCliente))]
        public IHttpActionResult GetActaLiberacionCliente(int id)
        {
            ActaLiberacionCliente actaLiberacionCliente = db.ActaLiberacionCliente.Find(id);
            if (actaLiberacionCliente == null)
            {
                return NotFound();
            }

            return Ok(actaLiberacionCliente);
        }

        // PUT: api/ActaLiberacionCliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActaLiberacionCliente(int id, ActaLiberacionCliente actaLiberacionCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actaLiberacionCliente.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(actaLiberacionCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaLiberacionClienteExists(id))
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

        // POST: api/ActaLiberacionCliente
        [ResponseType(typeof(ActaLiberacionCliente))]
        public IHttpActionResult PostActaLiberacionCliente(ActaLiberacionCliente actaLiberacionCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActaLiberacionCliente.Add(actaLiberacionCliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActaLiberacionClienteExists(actaLiberacionCliente.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = actaLiberacionCliente.CodProyecto }, actaLiberacionCliente);
        }

        // DELETE: api/ActaLiberacionCliente/5
        [ResponseType(typeof(ActaLiberacionCliente))]
        public IHttpActionResult DeleteActaLiberacionCliente(int id)
        {
            ActaLiberacionCliente actaLiberacionCliente = db.ActaLiberacionCliente.Find(id);
            if (actaLiberacionCliente == null)
            {
                return NotFound();
            }

            db.ActaLiberacionCliente.Remove(actaLiberacionCliente);
            db.SaveChanges();

            return Ok(actaLiberacionCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActaLiberacionClienteExists(int id)
        {
            return db.ActaLiberacionCliente.Count(e => e.CodProyecto == id) > 0;
        }
    }
}