using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSCore.Entity;

namespace VSCore.Concrete
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
        }

        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Branch> Branches  { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<CategoryBusness> CategoryBusnesses { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<News> Newses { get; set; }
        public virtual DbSet<TypesBusinesses> TypesBusnesses { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Useful> Usefuls { get; set; }
        public virtual DbSet<UsefulRubrics> UsefulRubricses { get; set; }
    }

}
