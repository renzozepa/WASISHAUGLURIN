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
    public class usuarioController : ApiController
    {
        private ModelSISHAUGLURIN db = new ModelSISHAUGLURIN();

        // GET: api/usuario
        public IQueryable<usuario> Getusuario()
        {
            return db.usuario;
        }

        // GET: api/usuario/5
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Getusuario(string id)
        {
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putusuario(string id, usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Usuario)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioExists(id))
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

        // POST: api/usuario
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Postusuario(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuario.Add(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (usuarioExists(usuario.Usuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.Usuario }, usuario);
        }

        // DELETE: api/usuario/5
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Deleteusuario(string id)
        {
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuarioExists(string id)
        {
            return db.usuario.Count(e => e.Usuario == id) > 0;
        }
    }
}