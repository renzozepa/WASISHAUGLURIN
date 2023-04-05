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
    public class ActaLiberacionInternaController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ActaLiberacionInterna
        public IQueryable<ActaLiberacionInterna> GetActaLiberacionInterna()
        {
            return db.ActaLiberacionInterna;
        }

        // GET: api/ActaLiberacionInterna/5
        [ResponseType(typeof(ActaLiberacionInterna))]
        public IHttpActionResult GetActaLiberacionInterna(int id)
        {
            ActaLiberacionInterna actaLiberacionInterna = db.ActaLiberacionInterna.Find(id);
            if (actaLiberacionInterna == null)
            {
                return NotFound();
            }

            return Ok(actaLiberacionInterna);
        }

        // PUT: api/ActaLiberacionInterna/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActaLiberacionInterna(int id, ActaLiberacionInterna actaLiberacionInterna)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actaLiberacionInterna.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(actaLiberacionInterna).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaLiberacionInternaExists(id))
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

        // POST: api/ActaLiberacionInterna
        [ResponseType(typeof(ActaLiberacionInterna))]
        public IHttpActionResult PostActaLiberacionInterna(ActaLiberacionInterna actaLiberacionInterna)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActaLiberacionInterna.Add(actaLiberacionInterna);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActaLiberacionInternaExists(actaLiberacionInterna.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = actaLiberacionInterna.CodProyecto }, actaLiberacionInterna);
        }

        // DELETE: api/ActaLiberacionInterna/5
        [ResponseType(typeof(ActaLiberacionInterna))]
        public IHttpActionResult DeleteActaLiberacionInterna(int id)
        {
            ActaLiberacionInterna actaLiberacionInterna = db.ActaLiberacionInterna.Find(id);
            if (actaLiberacionInterna == null)
            {
                return NotFound();
            }

            db.ActaLiberacionInterna.Remove(actaLiberacionInterna);
            db.SaveChanges();

            return Ok(actaLiberacionInterna);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActaLiberacionInternaExists(int id)
        {
            return db.ActaLiberacionInterna.Count(e => e.CodProyecto == id) > 0;
        }
    }
}