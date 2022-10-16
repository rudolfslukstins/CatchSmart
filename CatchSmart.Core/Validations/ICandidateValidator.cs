using CatchSmart.Core.Models;

namespace CatchSmart.Core.Validations
{
    public interface ICandidateValidator
    {
        bool IsValid(Candidate candidate);
    }
}