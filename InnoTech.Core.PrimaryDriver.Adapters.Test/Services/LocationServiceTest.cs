using InnoTech.Core.PrimaryDriver.Adapters.Services;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using System;
using Xunit;
using InnoTech.Core.Infratructure.Ports.Repositories;
using Moq;
using InnoTech.Core.Entity;
using FluentAssertions;
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Adapters.Validators;
using InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
       

        #region Constructor and Properties

        private readonly LocationServiceTestHelper _helper;

        public LocationServiceTest()
        {
            _helper = new LocationServiceTestHelper();
        }

        #endregion

        #region Create - Busines Logic

        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = null;
            Action action = () => new LocationService(locationRepository, null);
            action.Should().Throw<ParameterCannotBeNullException>().WithMessage("LocationRepository Parameter Can't be null");
        }

        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationValidator_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationValidator validator = null as LocationValidator;
            Action action = () => new LocationService(locationRepository, validator);
            action.Should().Throw<ParameterCannotBeNullException>().WithMessage("LocationValidator Parameter Can't be null");
        }

        [Fact]
        public void Create_WithLocationParameter_ShouldCallILocationValidatorsDefaultValidationMethodOnTime()
        {
            Mock<ILocationRepository> locationRepositoryMock = new Mock<ILocationRepository>();
            Mock<ILocationValidator> locationValidatorMock = new Mock<ILocationValidator>();
            LocationService locationService = new LocationService(locationRepositoryMock.Object, locationValidatorMock.Object);
            Location location = new Location
            {
                Name = "Hyd"
            };
            locationService.Create(location);
            locationValidatorMock.Verify(lm => lm.DefaultValidation(location), Times.Once);
        }

        #endregion

        #region Create - Busines Flow

        [Fact]
        public void Create_WithValidLocationParameter_ShouldCallILocationValidatorsDefaultValidationMethodOneTimeWithParam()
        {
            var validatorMock = _helper.LocationValidatorMock();
            var location = _helper.CreateVerify(validator: validatorMock.Object);
            validatorMock.Verify(locationValidator => locationValidator.DefaultValidation(location), Times.Once);
        }

        [Fact]
        public void Create_WithValidLocationParameter_ShouldCallIRepositoryAddMethodOneTimeWithParam()
        {
            var repositoryMock = _helper.LocationRepositoryMock();
            var location = _helper.CreateVerify(locationRepository: repositoryMock.Object);
            repositoryMock.Verify(locationRepository => locationRepository.Add(location), Times.Once);
        }

        #endregion

    }
}
