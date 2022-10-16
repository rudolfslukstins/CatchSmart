using CatchSmart.Core.Models;

namespace CatchSmart.Core.Validations
{
    public class CandidateValidator : ICandidateValidator
    {
        public bool IsValid(Candidate candidate)
        {
            if (candidate?.FirstName != null && candidate?.Lastname != null)
            {
                return true;
            }

            return false;
        }
    }
}