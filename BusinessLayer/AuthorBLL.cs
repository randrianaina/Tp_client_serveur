using DataRepository;
using IBusinessLayer;
using IDataRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthorBLL : IAuteurBLL
    {

        //on doit passer par l'interface de la couche DataAccessLayer
        IAuteurRepository _dataFactory;


        //Constructeur 1 - celui qui sera appelé
        public AuthorBLL() : this(new AuteurRepository())
        {
        }

        /// <summary>
        /// Constructeur 2
        /// Injection de dépendence par le constructeur
        /// </summary>
        /// <param name="dataFactory"></param>
        private AuthorBLL(IAuteurRepository dataFactory)
        {
            _dataFactory = dataFactory;
        }

        public IQueryable<Auteur> GetAuteurs()
        {
            return _dataFactory.GetAuteurs();
        }

        public async Task<Auteur> PostAuteur(Auteur author)
        {
            return await _dataFactory.PostAuteur(author);
        }


        public void Dispose()
        {
            if (_dataFactory != null)
                _dataFactory.Dispose();
        }
    }
}
