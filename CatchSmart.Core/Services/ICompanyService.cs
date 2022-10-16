using CatchSmart.Core.Models;

namespace CatchSmart.Core.Services
{
    public interface ICompanyService : IEntityService<Company>
    {
        Company GetCompanyByName(string name);
        Company AddCompany(string name);
        CompaniesPositions AddPosition(int companiesId, int positionId);

        void DeleteCompany(int id);
    }
}