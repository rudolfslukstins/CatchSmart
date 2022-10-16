using CatchSmart.Core.Models;
using CatchSmart.Core.Services;
using CatchSmart.Db;
using System.Collections.Generic;
using System.Linq;

namespace CatchSmart.Service
{
    public class CompanyPositionService : EntityService<CompaniesPositions> , ICompanyPositionService
    { 
        public CompanyPositionService(CatchSmartDbContext context) : base(context)
        {
        } 
        public Company GetCompanyFromPositionId(int positionId)
        {
            var position = _context.CompanyPositions.FirstOrDefault(p => p.PositionId == positionId);
            if (position == null) return null;

            return _context.Companies.FirstOrDefault(c => c.Id == position.CompanyId);
        }

        public List<Positions> GetCompanyPositionsList(string companyName)
        {
            var company = _context.Companies
                .FirstOrDefault(c => c.CompanyName.ToLower().Contains(companyName));
            if (company == null)
            {
                return new List<Positions>();
            }


            var positionIds = Query()
                .Where(c => c.CompanyId == company.Id)
                .Select(c => c.PositionId);
            
            return _context.Positions.Where(p => positionIds.Contains(p.Id)).ToList();
        }
    }
}