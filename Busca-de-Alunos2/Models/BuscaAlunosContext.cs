using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Busca_de_Alunos2.Models
{
    public class BuscaAlunosContext : DbContext
    {
        public BuscaAlunosContext()
            : base("BuscaAlunosContext")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Non delete cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}