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
    public class ProvedorController : ApiController {
        private DennikDBContex db = new DennikDBContex();
        [EnableQuery]
        // GET: api/Provedor
        public IQueryable<Provedor> GetProvedores () {
            return db.Provedores.AsQueryable();
        }
        [EnableQuery]
        // GET: api/Provedor/5
        [ResponseType(typeof(Provedor))]
        public async Task<IQueryable<Provedor>> GetProvedor (int id) {
            Provedor provedor = await db.Provedores.FindAsync(id);
            if (provedor == null) {
                return db.Provedores.DefaultIfEmpty();
            }

            return db.Provedores.Where(p => p.ProvedorId == id);
        }

        // PUT: api/Provedor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProvedor (int id, Provedor provedor) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != provedor.ProvedorId) {
                return BadRequest();
            }

            db.Entry(provedor).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ProvedorExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Provedor
        [ResponseType(typeof(Provedor))]
        public async Task<IHttpActionResult> PostProvedor (Provedor provedor) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Provedores.Add(provedor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = provedor.ProvedorId }, provedor);
        }

        // DELETE: api/Provedor/5
        [ResponseType(typeof(Provedor))]
        public async Task<IHttpActionResult> DeleteProvedor (int id) {
            Provedor provedor = await db.Provedores.FindAsync(id);
            if (provedor == null) {
                return NotFound();
            }

            db.Provedores.Remove(provedor);
            await db.SaveChangesAsync();

            return Ok(provedor);
        }

        protected override void Dispose (bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvedorExists (int id) {
            return db.Provedores.Count(e => e.ProvedorId == id) > 0;
        }
    }
}