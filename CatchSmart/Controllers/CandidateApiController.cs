using CatchSmart.Core.Models;
using CatchSmart.Core.Services;
using CatchSmart.Core.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CatchSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateApiController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IEntityService<CandidatePositions> _candidatePositionService;
        private readonly IEnumerable<ICandidateValidator> _candidatesValidator;

        public CandidateApiController(ICandidateService candidateService,
            IEntityService<CandidatePositions> candidatePositionService,
            IEnumerable<ICandidateValidator> candidateValidators)
        {
            _candidateService = candidateService;
            _candidatePositionService = candidatePositionService;
            _candidatesValidator = candidateValidators;
        }

        [Route("create-candidates")]
        [HttpPut]
        public IActionResult CreateCandidate(string firstName, string lastName, string skillSet)
        {
            var candidate = _candidateService.AddCandidate(firstName, lastName, skillSet);

            return Created("", candidate);
        }

        [Route("candidates/add-position")]
        [HttpPut]
        public IActionResult AddCandidatePosition(string searchCandidate, int positionId)
        {
            var candidate = _candidateService.GetCandidateByName(searchCandidate);
            if (_candidatesValidator.All(c => c.IsValid(candidate)))
            {
                var candidatePosition = _candidateService.AddCandidatePositionsPosition(candidate.Id, positionId);
                _candidatePositionService.Create(candidatePosition);
                return Created("", candidatePosition);
            }

            return NotFound();
        }

        [Route("candidates/get-candidate-list-applied-to/{search}")]
        [HttpGet]
        public IActionResult SearchCandidateListAppliedTo(string search)
        {
            var companyList = _candidateService.GetCandidateCompanies(search);
            if (companyList == null)
            {
                return NotFound();
            }

            return Ok(companyList);
        }

        [Route("candidates/get-candidates")]
        [HttpGet]
        public IActionResult SearchCandidates(string search)
        {
            var candidate = _candidateService.GetCandidates(search);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [Route("candidates/update-candidate-skills")]
        [HttpPatch]
        public IActionResult UpdateCandidate(string candidateToUpdate, string updateSkills)
        {
            var candidate = _candidateService.GetCandidateByName(candidateToUpdate);

            if (_candidatesValidator.All(c => c.IsValid(candidate)))
            {
                candidate.SkillSets = updateSkills;
                _candidateService.Update(candidate);
                return Ok(candidate);
            }

            return NotFound();
        }

        [Route("Delete-candidate")]
        [HttpDelete]
        public IActionResult DeleteCompany(string name)
        {
            var candidate = _candidateService.GetCandidateByName(name);

            if (_candidatesValidator.All(c => c.IsValid(candidate)))
            {
                _candidateService.Delete(candidate);
                return Ok(candidate);
            }

            return NotFound();
        }
    }
}
