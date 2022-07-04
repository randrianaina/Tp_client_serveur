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
    public class BookBLL : ILivreBLL
    {

        //on doit passer par l'interface de la couche DataAccessLayer
        ILivreRepository _dataFactory;


        //Constructeur 1 - celui qui sera appelé
        public BookBLL() : this(new LivreRepository())
        {
        }

        private BookBLL(ILivreRepository dataFactory)
        {
            _dataFactory = dataFactory;
        }

        public IQueryable<Livre> GetLivres()
        {
            return _dataFactory.GetLivres();
        }

        public async Task<Livre> PostLivre(Livre book)
        {
            return await _dataFactory.PostLivre(book);
        }


        public void Dispose()
        {
            if (_dataFactory != null)
                _dataFactory.Dispose();
        }
    }
}
