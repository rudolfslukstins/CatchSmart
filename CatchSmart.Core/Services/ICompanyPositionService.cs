using CatchSmart.Core.Models;
using System.Collections.Generic;

namespace CatchSmart.Core.Services
{
    public interface ICompanyPositionService : IEntityService<CompaniesPositions>
    {
        Company GetCompanyFromPositionId(int positionId);

        List<Positions> GetCompanyPositionsList(string companyName);
    }
}