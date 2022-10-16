using CatchSmart.Core.Models;
using CatchSmart.Core.Validations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatchSmart.Tests
{
    [TestClass]
    public class CandidateTests
    {
        private Candidate _candidate;
        private ICandidateValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _candidate = new Candidate();
            _validator = new CandidateValidator();
        }
        [TestMethod]
        public void IsValid_SearchCandidateWhenThereIsNoCandidate_ShouldBeFalse()
        {
            var result = _validator.IsValid(_candidate);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsValid_SearchCandidateWhenThereIsCandidate_ShouldBeTrue()
        {
            _candidate.FirstName = "valdis";
            _candidate.Lastname = "c#";
            var result = _validator.IsValid(_candidate);
            result.Should().BeTrue();
        }
    }
}
