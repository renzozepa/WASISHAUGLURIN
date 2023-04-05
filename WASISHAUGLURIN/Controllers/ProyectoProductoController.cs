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
    public class ProyectoProductoController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/ProyectoProducto
        public IQueryable<ProyectoProducto> GetProyectoProducto()
        {
            return db.ProyectoProducto;
        }

        // GET: api/ProyectoProducto/5
        [ResponseType(typeof(ProyectoProducto))]
        public IHttpActionResult GetProyectoProducto(int id)
        {
            ProyectoProducto proyectoProducto = db.ProyectoProducto.Find(id);
            if (proyectoProducto == null)
            {
                return NotFound();
            }

            return Ok(proyectoProducto);
        }

        // PUT: api/ProyectoProducto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProyectoProducto(int id, ProyectoProducto proyectoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyectoProducto.CodProyecto)
            {
                return BadRequest();
            }

            db.Entry(proyectoProducto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoProductoExists(id))
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

        // POST: api/ProyectoProducto
        [ResponseType(typeof(ProyectoProducto))]
        public IHttpActionResult PostProyectoProducto(ProyectoProducto proyectoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProyectoProducto.Add(proyectoProducto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProyectoProductoExists(proyectoProducto.CodProyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proyectoProducto.CodProyecto }, proyectoProducto);
        }

        // DELETE: api/ProyectoProducto/5
        [ResponseType(typeof(ProyectoProducto))]
        public IHttpActionResult DeleteProyectoProducto(int id)
        {
            ProyectoProducto proyectoProducto = db.ProyectoProducto.Find(id);
            if (proyectoProducto == null)
            {
                return NotFound();
            }

            db.ProyectoProducto.Remove(proyectoProducto);
            db.SaveChanges();

            return Ok(proyectoProducto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProyectoProductoExists(int id)
        {
            return db.ProyectoProducto.Count(e => e.CodProyecto == id) > 0;
        }
    }
}