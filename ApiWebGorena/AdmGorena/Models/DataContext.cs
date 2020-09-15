namespace AdmGorena.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<AdmGorena.Models.Gorena> Gorenas { get; set; }
    }
}