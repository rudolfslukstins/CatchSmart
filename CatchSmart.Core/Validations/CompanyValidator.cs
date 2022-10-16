using CatchSmart.Core.Models;

namespace CatchSmart.Core.Validations
{
    public class CompanyValidator : ICompanyValidator
    {
        public bool IsValid(Company company)
        {
            return !string.IsNullOrEmpty(company?.CompanyName);
        }
    }
}