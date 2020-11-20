﻿using InnoTech.Core.PrimaryDriver.Ports.Services;
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
using InnoTech.Core.PrimaryDriver.Adapters.Validators;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = null;
            Action action = () => new LocationService(locationRepository,null);
            action.Should().Throw<ParameterCannotBeNullException>().WithMessage("LocationRepository Parameter Can't be null");
        }

        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationValidator_ThrowsNullReferenceException()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            ILocationValidator validator = null as LocationValidator;
            Action action = () => new LocationService(locationRepository, validator );
            action.Should().Throw<ParameterCannotBeNullException>().WithMessage("LocationValidator Parameter Can't be null");
        }

        [Fact]
        public void Create_WithLocationParameter_ShouldCallILocationValidatorsDefaultValidationMethodOnTime()
        {
            ILocationRepository locationRepository = new Mock<ILocationRepository>().Object;
            Mock<ILocationValidator> locationValidatorMock = new Mock<ILocationValidator>();
            LocationService locationService = new LocationService(locationRepository, locationValidatorMock.Object);
            Location location = new Location
            {
                Name = "Hyd"
            };
            locationService.Create(location);
            locationValidatorMock.Verify(lm => lm.DefaultValidation(location),Times.Once);
        }
    }
}
