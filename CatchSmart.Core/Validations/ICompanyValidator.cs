using CatchSmart.Core.Models;

namespace CatchSmart.Core.Validations
{
    public interface ICompanyValidator
    {
        bool IsValid(Company company);
    }
}