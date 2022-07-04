using IDataRepository;
using Models;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class AuteurRepository : IAuteurRepository
    {


        //context DB
        //injection de dépenence par la propriété
        private ConDB _context = null;

        //Constructeur qui instance une ConDB avec le pattern singleton
        //Injection de dépendence par le constructeur
        public AuteurRepository()
        {
            _context = ConDB.Instance;
        }

        /// <summary>
        /// Récupere le liste des auteurs
        /// </summary>
        /// <returns></returns>
        public IQueryable<Auteur> GetAuteurs()
        {
            return _context.Auteurs;
        }


        /// <summary>
        /// Insertion d'un auteur
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        //public Auteur PostAuteur(Auteur author)
        //{
        //    Auteur aut = _context.Auteurs.Add(author);
        //    _context.SaveChangesAsync();
        //    return aut;
        //}


        public async Task<Auteur> PostAuteur(Auteur author)
        {
            Auteur aut = _context.Auteurs.Add(author);
            await _context.SaveChangesAsync();
            return aut;
        }


        //Cette méthode est à implementer vu que cette classe implemente l'interface IAuteurRepository,
        //lui même implemente IDisposable
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
