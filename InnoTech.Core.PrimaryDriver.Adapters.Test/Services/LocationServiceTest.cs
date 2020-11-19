using InnoTech.Core.PrimaryDriver.Ports.Services;
using InnoTech.Core.PrimaryDriver.Adapters.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using InnoTech.Core.Infratructure.Ports.Repositories;
using Moq;
using InnoTech.Core.Entity;
using FluentAssertions;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = null;
            Assert.Throws<NullReferenceException>(() => new LocationService(locationRepository));
        }

        [Fact]
        public void Create_WithLocationAsNull_ThrowsNullReferenceExceptionWithCorrectMessage()
        {
            var locationRepository = new Mock<ILocationRepository>().Object;
            ILocationService locationService = new LocationService(locationRepository);
            try
            {
                Action action=()=>locationService.Create(null);
                action.Should().Throw<NullReferenceException>().WithMessage("Location can't be null");
                //locationService.Create(null);
                //Assert.True(false, "We should never gete here.shpul;d throw exception");
            }
            catch (NullReferenceException e)
            {
                Assert.Equal("Location can't be null", e.Message);
            }
        }

        [Fact]
        public void Create_WithLocationAsNull_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationService locationService = new LocationService(locationRepository);
            Assert.Throws<NullReferenceException>(()=>locationService.Create(null as Location));
        }
    }
}
