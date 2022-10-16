using CatchSmart.Core.Models;
using CatchSmart.Core.Validations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatchSmart.Tests
{
    [TestClass]
    public class CompanyValidatorTests
    {
        private Company _company;
        private ICompanyValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _company = new Company();
            _validator = new CompanyValidator();
        }
        [TestMethod]
        public void IsValid_SearchCompanyWhenThereIsNoCompany_ShouldBeFalse()
        {
            var result = _validator.IsValid(_company);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_SearchCompanyWhenThereIsCompany_ShouldBeTrue()
        {
            _company.CompanyName = "CatchSmart";
            var result = _validator.IsValid(_company);
            result.Should().BeTrue();
        }
    }
}