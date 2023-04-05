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
    public class ProyectoElementoController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ProyectoElemento
        public IQueryable<ProyectoElemento> GetProyectoElemento()
        {
            return db.ProyectoElemento;
        }

        // GET: api/ProyectoElemento/5
        [ResponseType(typeof(ProyectoElemento))]
        public IHttpActionResult GetProyectoElemento(int id)
        {
            ProyectoElemento proyectoElemento = db.ProyectoElemento.Find(id);
            if (proyectoElemento == null)
            {
                return NotFound();
            }

            return Ok(proyectoElemento);
        }

        // GET: api/ProyectoElemento/5
        public IQueryable<ProyectoElemento> GetProyectoElementoCod(int proyecto , string periodo)
        {
            return db.ProyectoElemento.Where(x => x.CodProyecto == proyecto && x.CodPeriodo == periodo);
        }

        // GET: api/ProyectoElemento/5
        public IQueryable<ProyectoElemento> GetProyectoElementoCod(int proyecto)
        {
            return db.ProyectoElemento.Where(x => x.CodProyecto == proyecto);
        }

        // PUT: api/ProyectoElemento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyectoElemento(int id, ProyectoElemento proyectoElemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectoElemento.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(proyectoElemento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoElementoExists(id))
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

        // POST: api/ProyectoElemento
        [ResponseType(typeof(ProyectoElemento))]
        public IHttpActionResult PostProyectoElemento(ProyectoElemento proyectoElemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProyectoElemento.Add(proyectoElemento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyectoElementoExists(proyectoElemento.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proyectoElemento.CodProyecto }, proyectoElemento);
        }

        // DELETE: api/ProyectoElemento/5
        [ResponseType(typeof(ProyectoElemento))]
        public IHttpActionResult DeleteProyectoElemento(int id)
        {
            ProyectoElemento proyectoElemento = db.ProyectoElemento.Find(id);
            if (proyectoElemento == null)
            {
                return NotFound();
            }

            db.ProyectoElemento.Remove(proyectoElemento);
            db.SaveChanges();

            return Ok(proyectoElemento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyectoElementoExists(int id)
        {
            return db.ProyectoElemento.Count(e => e.CodProyecto == id) > 0;
        }
    }
}