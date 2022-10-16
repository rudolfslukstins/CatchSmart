using System.Linq;
using System.Runtime.CompilerServices;
using CatchSmart.Core.Models;
using CatchSmart.Core.Services;
using CatchSmart.Db;

namespace CatchSmart.Service
{
    public class CompanyService : EntityService<Company>, ICompanyService
    {
        public CompanyService(CatchSmartDbContext context) : base(context)
        {
        }

        public Company GetCompanyByName(string name)
        {
            return _context.Companies.FirstOrDefault(c => c.CompanyName == name);
        }

        public Company AddCompany(string name)
        {
            var company = new Company
            {
                CompanyName = name,
            };
            Create(company);
            return company;
        }

        public CompaniesPositions AddPosition(int companiesId, int positionId)
        {
            var companyPositions = new CompaniesPositions
            {
                CompanyId = companiesId,
                PositionId = positionId,
            };
            Create(companyPositions);

            return companyPositions;
        }

        public void DeleteCompany(int id)
        {
            var company = Query().SingleOrDefault(c => c.Id == id);
            var companyPositions = _context.CompanyPositions
                .Where(cp => cp.CompanyId == id);
            var positions = _context.Positions
                .Where(p => companyPositions
                    .Any(cp => cp.PositionId == p.Id));
            Delete(company);
            _context.CompanyPositions.RemoveRange(companyPositions);
            _context.Positions.RemoveRange(positions);
            _context.SaveChanges();
        }
    }
}