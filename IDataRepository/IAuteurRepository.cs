using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataRepository
{
    public interface IAuteurRepository :IDisposable
    {

        IQueryable<Auteur> GetAuteurs();

        Task<Auteur> PostAuteur(Auteur author);
    }
}
