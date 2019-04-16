using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public virtual DbSet<AboutUs> AboutUses { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessHelpers> BusinessHelperses { get; set; }
        public virtual DbSet<CategoryBusness> CategoryBusnesses { get; set; }
        public virtual DbSet<Jobs> Jobses { get; set; }
        public virtual DbSet<News> Newses { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PaymentTicket> PaymentTickets { get; set; }
        public virtual DbSet<PlacementOnSite> PlacementOnSites { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<Useful> Usefuls { get; set; }
        public virtual DbSet<UsefulRubrics> UsefulRubricses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(20, 5));
        }
    }

}
