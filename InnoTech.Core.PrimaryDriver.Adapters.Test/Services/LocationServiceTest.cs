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
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;

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
                action.Should().Throw<ParameterCannotBeNullException>().WithMessage("Location Parameter Can't be null");
                //locationService.Create(null);
                //Assert.True(false, "We should never gete here.shpul;d throw exception");
            }
            catch (NullReferenceException e)
            {
                Assert.Equal("Location can't be null", e.Message);
            }
        }

        [Fact]
        public void Create_WithLocationAsNull_ThrowsParameterCannotBeNullExceptionWithLocationMessage()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationService locationService = new LocationService(locationRepository);
            Assert.Throws<ParameterCannotBeNullException>(()=>locationService.Create(null as Location));
        }

        [Fact]
        public void CreateLocation_WithEmptyName_ThrowsPropertyCannotBeEmptyException()
        {
            var location = new Location();
            location.Name = "";
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationService locationService = new LocationService(locationRepository);
            //fluent assertion used
            Action action = () => locationService.Create(location);
            action.Should().Throw<PropertyCannotBeEmptyException>()
                .And.ParamName.Should().Be("Name needs to be a value");
        }

        [Fact]
        public void CreateLocation_withNameLessThan2Characters_ThrowsArgumentOutOfRangeException()
        {
            var location = new Location();
            location.Name = "A";
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationService locationService = new LocationService(locationRepository);
            Action action = () => locationService.Create(location);
            action.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("Name must be 2 or more characters");
        }

    }
}
