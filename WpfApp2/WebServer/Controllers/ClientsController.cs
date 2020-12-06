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
using WpfApp2.DataBase;

namespace WebServer.Controllers
{
    public class ClientsController : ApiController
    {
        private MedicDb db = new MedicDb();

        // GET: api/Clients
        public IEnumerable<Clients> GetClients()
        {
            return db.Clients.ToList();
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> GetClients(int id)
        {
            Clients clients = await db.Clients.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClients(int id, Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clients.Id)
            {
                return BadRequest();
            }

            db.Entry(clients).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> PostClients(Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(clients);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clients.Id }, clients);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Clients))]
        public async Task<IHttpActionResult> DeleteClients(int id)
        {
            Clients clients = await db.Clients.FindAsync(id);
            if (clients == null)
            {
                return NotFound();
            }

            db.Clients.Remove(clients);
            await db.SaveChangesAsync();

            return Ok(clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}