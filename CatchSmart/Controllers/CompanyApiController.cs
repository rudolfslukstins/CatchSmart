using CatchSmart.Core.Services;
using CatchSmart.Core.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CatchSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanyPositionService _companiesPositionService;
        private readonly IPositionService _positionService;
        private readonly IEnumerable<ICompanyValidator> _companyValidator;

        public CompanyApiController(ICompanyService companyService,
            ICompanyPositionService companiesPositionService,
            IPositionService positionService,
            IEnumerable<ICompanyValidator> companyValidator)
        {
            _companyService = companyService;
            _companiesPositionService = companiesPositionService;
            _positionService = positionService;
            _companyValidator = companyValidator;
        }

        [Route("create-companies")]
        [HttpPut]
        public IActionResult PutCompany(string name)
        {
            var company = _companyService.AddCompany(name);

            return Created("", company);
        }

        [Route("companies/add-position")]
        [HttpPut]
        public IActionResult AddCompanyPosition(string title, string companySearch)
        {
            var newPosition = _positionService.AddPositions(title);
            var keyword = companySearch.ToLower().Trim();
            var company = _companyService.Query()
                .FirstOrDefault(c => c.CompanyName.ToLower().Contains(keyword));
            if (_companyValidator.All(c => c.IsValid(company)))
            {
                company.OpenPositions++;
                _positionService.Create(newPosition);
                var companiesPositions = _companyService.AddPosition(company.Id, newPosition.Id);
                Created("", companiesPositions);

                return Created("", newPosition);
            }

            return BadRequest();
        }

        [Route("company-search/{search}")]
        [HttpGet]
        public IActionResult SearchCompany(string search)
        {
            var keyword = search.ToLower().Trim();
            var company = _companyService.Query()
                .FirstOrDefault(c => c.CompanyName.ToLower().Contains(keyword));
            if (_companyValidator.All(c => c.IsValid(company)))
            {
                return Ok(company);
            }

            return NotFound(search);
        }

        [Route("company-search-open-positions/{search}")]
        [HttpGet]
        public IActionResult SearchCompanyOpenPositions(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest();
            }

            search = search.ToLower().Trim();
            var positions = _companiesPositionService.GetCompanyPositionsList(search);

            return Ok(positions);
        }

        [Route("companies/{id}")]
        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);

            return Ok(id);
        }
    }
}
