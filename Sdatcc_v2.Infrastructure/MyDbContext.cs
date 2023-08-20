/*using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sdatcc_v2.Infrastructure.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sdatcc_v2.Infrastructure
{
    public class MyDbContext : DbContext
    {
        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
         {


         }
        /
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             if (!optionsBuilder.IsConfigured)
             {

                 string cnnString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=sdatccdb;server=(LocalDb)\\MSSQLLocalDB";
                //optionsBuilder.UseSqlServer(cnnString);
                optionsBuilder.UseSqlServer("cnnString", b => b.MigrationsAssembly("Sdatcc_v2.Infrastructure"));

            }
            


        }


        public DbSet<AlunoEntity> Alunos { get; set; }
        public DbSet<ProfessorEntity> Professores { get; set; }
        public DbSet<TccEntity> Tccs { get; set; }
        public DbSet<ArquivoEntity> Arquivos { get; set; }
        public DbSet<LoginEntity> Logins { get; set; }

    }

 }*/


using System;
using System.Collections.Generic;
using System.Text;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Sdatcc_v2.Infrastructure.Entities;

namespace Sdatcc_v2.Infrastructure
{
	public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //  string cnnString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=sdatccdb;server=(LocalDb)\\MSSQLLocalDB";
                //optionsBuilder.UseSqlServer(cnnString);
                string cnnString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=sdatccdbv2;server=(LocalDb)\\MSSQLLocalDB";
                optionsBuilder.UseSqlServer(cnnString);
            }

        }

        public DbSet<AlunoEntity> Alunos { get; set; }
        public DbSet<ProfessorEntity> Professores { get; set; }
        public DbSet<TccEntity> Tccs { get; set; }
        public DbSet<ArquivoEntity> Arquivos { get; set; }
        public DbSet<LoginEntity> Logins { get; set; }




    }
}