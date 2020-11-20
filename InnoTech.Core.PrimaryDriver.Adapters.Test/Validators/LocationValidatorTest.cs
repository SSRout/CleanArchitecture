using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.Infratructure.Ports.Repositories;
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Adapters.Services;
using InnoTech.Core.PrimaryDriver.Adapters.Validators;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Validators
{
    public class LocationValidatorTest
    {
        [Fact]
        public void DefaultValidation_WithNullLocation_ThrowsNewParameterCannotBeNullException()
        {
            ILocationValidator validator = new LocationValidator();
            Action action=()=>validator.DefaultValidation(null as Location);
            action.Should().Throw<ParameterCannotBeNullException>();
        }

        [Fact]
        public void DefaultValidation_WithEmptyName_ThrowsPropertyCannotBeEmptyException()
        {
            ILocationValidator validator = new LocationValidator();
            var location = new Location();
            location.Name = "";
            Action action = () => validator.DefaultValidation(location);
            action.Should().Throw<PropertyCannotBeEmptyException>()
                .And.ParamName.Should().Be("Name needs to be a value");
        }

        [Fact]
        public void DefaultValidation_withNameLessThan2Characters_ThrowsArgumentOutOfRangeException()
        {
            ILocationValidator validator = new LocationValidator();
            var location = new Location();
            location.Name = "A";
            Action action = () => validator.DefaultValidation(location);
            action.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("Name must be 2 or more characters");
        }

    }
}
