using CatchSmart.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CatchSmart.Db
{
    public class CatchSmartDbContext : DbContext
    {
        public CatchSmartDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<CompaniesPositions> CompanyPositions { get; set; }
        public DbSet<CandidatePositions> CandidatePositions { get; set; }
    }
}
