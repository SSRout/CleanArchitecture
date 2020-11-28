using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.Infratructure.Ports.Repositories;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;
using InnoTech.Test.Helpers.Entities;
using InnoTech.Test.Helpers.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace InnoTech.Infrastructure.Adapters.SQLData.Test.Repositories
{
    public class LocationRepositoryTest
    {
        private readonly LocationTestHelper _locationTestHelper;
        private readonly LocationRepositoryTestHelper _locationRepositoryTestHelper;
        public LocationRepositoryTest()
        {
            _locationRepositoryTestHelper = new LocationRepositoryTestHelper();
            _locationTestHelper = new LocationTestHelper();
        }
        [Fact]
        public void CreateLocationRepository_WithEggProductionDbContextAsNullParam_ThrowsException()
        {
            Action action=() =>new  LocationRepository(null as EggProductionDbContext);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void LocationReplository_ShouldImplimentILocationReplository()
        {
            var context= new Mock<EggProductionDbContext>().Object;
            var repo = new LocationRepository(context);
            repo.Should().BeAssignableTo<ILocationRepository>();
        }

        [Fact]
        public void AddInLocationRepository_WithNullLocation_ThrowsException()
        {
            EggProductionDbContext context = new Mock<EggProductionDbContext>().Object;

            ILocationRepository repo = new LocationRepository(context);
            Action action = () => repo.Add(null as Location);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void Add_WithValidLocation_CallsAddOnDbcontext()
        {
            var contextMock = new Mock<EggProductionDbContext>();
            var repo = new LocationRepository(contextMock.Object);
            var location = _locationTestHelper.ValidLocation();
            repo.Add(location);
            contextMock.Verify(c => c.Add(location), Times.Once);
        }

        [Fact]
        public void Add_WithValidLocation_AddsToDbSetChangeTracker()
        {
            var location = _locationTestHelper.ValidLocation();
            var changeTrackerListLocations = new List<Location>();
            var contextMock = new Mock<EggProductionDbContext>();
            contextMock.Setup(c => c.Add(location))
                .Callback<Location>(l=> changeTrackerListLocations.Add(l));
            var repo = _locationRepositoryTestHelper.GetLocationRepository(contextMock.Object);
            repo.Add(location);
            Assert.Equal(location, changeTrackerListLocations.First());
        }
    }
}
