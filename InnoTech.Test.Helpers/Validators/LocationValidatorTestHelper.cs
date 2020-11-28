using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriver.Adapters.Validators;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using System;

namespace InnoTech.Test.Helpers.Validators
{
    public class LocationValidatorTestHelper
    {
        public void DefaultValidation<TE>(Location location = null, string message = null) where TE : Exception
        {
            Action action = () => LocationValidator().DefaultValidation(location);
            if (message != null)
            {
                action.Should().Throw<TE>()
                    .And.Message.Should().Be(message);
            }
            else
            {
                action.Should().Throw<TE>();
            }

        }

        private ILocationValidator LocationValidator()
        {
            return new LocationValidator();
        }
    }
}
