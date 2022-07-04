using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataRepository
{
    public interface ILivreRepository : IDisposable
    {

        IQueryable<Livre> GetLivres();

        Task<Livre> PostLivre(Livre book);
    }
}
