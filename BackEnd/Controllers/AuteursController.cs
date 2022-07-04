using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IBusinessLayer;
using Models;

namespace BackEnd.Controllers
{
    public class AuteursController : ApiController
    {

        //injection des dépendences en utilisant Castle Windsor-------------------------------------
        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();
            //enregistrement dans le container
            container.Register(Component.For<IAuteurBLL>().ImplementedBy<AuthorBLL>());
            return container;
        }

        //Résolution du service pour l'utilisation
        IAuteurBLL context = InitDependency().Resolve<IAuteurBLL>();
        //-------------------------------------------------------------------------




        // GET: api/Auteurs
        public IQueryable<Auteur> GetAuteurs()
        {
            return (context.GetAuteurs());           
        }



        // POST: api/Auteurs
        [ResponseType(typeof(Auteur))]
        public async Task<IHttpActionResult> PostAuteur(Auteur auteur)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await context.PostAuteur(auteur);
            return CreatedAtRoute("DefaultApi", new { id = auteur.IdAuteur }, auteur);
        }




        // GET: api/Auteurs/5
        //[ResponseType(typeof(Auteur))]
        //public async Task<IHttpActionResult> GetAuteur(int id)
        //{
        //    Auteur auteur = await db.Auteurs.FindAsync(id);
        //    if (auteur == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(auteur);
        //}

        // PUT: api/Auteurs/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutAuteur(int id, Auteur auteur)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != auteur.IdAuteur)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(auteur).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuteurExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Auteurs
        //[ResponseType(typeof(Auteur))]
        //public async Task<IHttpActionResult> PostAuteur(Auteur auteur)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Auteurs.Add(auteur);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = auteur.IdAuteur }, auteur);
        //}

        //// DELETE: api/Auteurs/5
        //[ResponseType(typeof(Auteur))]
        //public async Task<IHttpActionResult> DeleteAuteur(int id)
        //{
        //    Auteur auteur = await db.Auteurs.FindAsync(id);
        //    if (auteur == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Auteurs.Remove(auteur);
        //    await db.SaveChangesAsync();

        //    return Ok(auteur);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool AuteurExists(int id)
        //{
        //    return db.Auteurs.Count(e => e.IdAuteur == id) > 0;
        //}
    }
}