namespace GOOS_Sample.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BudgetsRepository : DbContext, IBudgetsRepository
    {
        public BudgetsRepository()
            : base( "name=BudgetsRepository" )
        {
        }

        public virtual DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Budget>()
                .Property( e => e.Amount )
                .HasPrecision( 18 , 0 );

            modelBuilder.Entity<Budget>()
                .Property( e => e.YearMonth )
                .IsUnicode( false );
        }
    }
}
