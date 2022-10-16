using System.Collections.Generic;
using System.Linq;
using CatchSmart.Core.Models;
using CatchSmart.Core.Services;
using CatchSmart.Db;

namespace CatchSmart.Service
{
    public class CandidateService : EntityService<Candidate>, ICandidateService
    {
        public CandidateService(CatchSmartDbContext context) : base(context)
        {
        }

        public Candidate GetCandidateByName(string name)
        {
            return _context.Candidates.FirstOrDefault(c => c.FirstName == name);
        }

        public CandidatePositions AddCandidatePositionsPosition(int candidateId, int positionId)
        {
            var candidatePositions = new CandidatePositions
            {
                CandidateId = candidateId,
                PositionId = positionId,
            };
            Create(candidatePositions);
            
            return candidatePositions;
        }

        public Candidate AddCandidate(string firstName, string lastName, string skillSet)
        {
            
            var candidate = new Candidate
            {
                FirstName = firstName,
                Lastname = lastName,
                SkillSets = skillSet,
            };
            Create(candidate);
            
            return candidate;
        }

        public List<Company> GetCandidateCompanies(string search)
        {
            var candidate = GetCandidateByName(search);
            var candidatePositions = _context.CandidatePositions
                .Where(cp => cp.CandidateId == candidate.Id);
            var companyPositions = _context.CompanyPositions
                .Where(cp => candidatePositions
                    .Any(x => x.PositionId == cp.PositionId));
            var companies = _context.Companies
                .Where(c => companyPositions.Any(cp => cp.CompanyId == c.Id));
            
            return companies.ToList();
        }

        public List<Candidate> GetCandidates(string searchCandidates)
        {
            var keyword = searchCandidates.ToLower();
            var candidateList = Query().Where(c => c.FirstName.ToLower().Trim().Contains(keyword) ||
                                               c.Lastname.ToLower().Trim().Contains(keyword));
            return candidateList.ToList();
        }
    }
}