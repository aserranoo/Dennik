using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DennikDB.Entities;
using System.Web.Http.Cors;
using System.Web.OData;

namespace DennikAPI.Controllers {
    [EnableCors("http://localhost:46662", "*", "*")]
    public class ArticuloController : ApiController {
        private DennikDBContex db = new DennikDBContex();
        [EnableQuery()]
        // GET: api/Articulo
        public IQueryable<Articulo> GetInventario() {            
            return db.Inventario.AsQueryable();
        }
        [EnableQuery]
        // GET: api/Articulo/5
        [ResponseType(typeof(Articulo))]
        public async Task<IQueryable<Articulo>> GetArticulo(int id) {                                    
            Articulo articulo = await db.Inventario.FindAsync(id);            
            if (articulo == null) {
                return db.Inventario.DefaultIfEmpty();
            }

            return db.Inventario.Where(p => p.ArticuloId == id);
        }

        // PUT: api/Articulo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArticulo(int id, Articulo articulo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != articulo.ArticuloId) {
                return BadRequest();
            }

            db.Entry(articulo).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ArticuloExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Articulo
        [ResponseType(typeof(Articulo))]
        public async Task<IHttpActionResult> PostArticulo(Articulo articulo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Inventario.Add(articulo);
            await db.SaveChangesAsync();
            articulo.Art.CodigoProducto = articulo.ArticuloId;
            return CreatedAtRoute("DefaultApi", new { id = articulo.ArticuloId }, articulo);
        }

        // DELETE: api/Articulo/5
        [ResponseType(typeof(Articulo))]
        public async Task<IHttpActionResult> DeleteArticulo(int id) {
            Articulo articulo = await db.Inventario.FindAsync(id);
            if (articulo == null) {
                return NotFound();
            }

            db.Inventario.Remove(articulo);
            await db.SaveChangesAsync();

            return Ok(articulo);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticuloExists(int id) {
            return db.Inventario.Count(e => e.ArticuloId == id) > 0;
        }
    }
}