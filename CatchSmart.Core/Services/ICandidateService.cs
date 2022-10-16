using CatchSmart.Core.Models;
using System.Collections.Generic;

namespace CatchSmart.Core.Services
{
    public interface ICandidateService : IEntityService<Candidate>
    {
        Candidate GetCandidateByName(string name);
        CandidatePositions AddCandidatePositionsPosition(int candidateId, int positionId);
        Candidate AddCandidate(string firstName, string lastName, string skillSet);
        List<Company> GetCandidateCompanies(string search);
        List<Candidate> GetCandidates(string searchCandidates);
    }
}