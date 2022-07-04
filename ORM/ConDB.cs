using Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ORM
{
    public partial class ConDB : DbContext
    {

        //le constructeur
        public ConDB()
            : base("name=ConDB")
        {
        }

        //------------------------------------------------------------------------------------------------------------------------------

        //patern singleton -- Pour disposer d'une seul instance et éviter des connexions inutiles qui dégradent les performances de la BDD
        private static readonly object _padlock = new object();

        private static ConDB _instance = null;
        
        //méthode statique qui renvoit une instance de ConDB
        public static ConDB Instance
        {
            get
            {
                //check pour éviter l'accés multi-thread
                lock (_padlock)
                {
                    if (_instance == null) //si null on instancié
                    {
                        _instance = new ConDB();
                    }
                    return _instance;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------


        public virtual DbSet<Auteur> Auteurs { get; set; }
        public virtual DbSet<Livre> Livres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteur>()
                .HasMany(e => e.Livres)
                .WithRequired(e => e.Auteur)
                .WillCascadeOnDelete(false);
        }
    }
}
