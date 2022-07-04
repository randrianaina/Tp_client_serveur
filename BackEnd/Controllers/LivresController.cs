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
    public class LivresController : ApiController
    {
        //private BackEndContext db = new BackEndContext();

        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();
            //enregistrement dans le container
            container.Register(Component.For<ILivreBLL>().ImplementedBy<BookBLL>());
            return container;
        }

        //Résolution du service pour l'utilisation
        ILivreBLL context = InitDependency().Resolve<ILivreBLL>();
        //-------------------------------------------------------------------------




        // GET: api/Livres
        public IQueryable<Livre> GetLivres()
        {
            return (context.GetLivres());
        }



        // POST: api/Auteurs
        [ResponseType(typeof(Livre))]
        public async Task<IHttpActionResult> PostAuteur(Livre livre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await context.PostLivre(livre);
            return CreatedAtRoute("DefaultApi", new { id = livre.IdLivre }, livre);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}