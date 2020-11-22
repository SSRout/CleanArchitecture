using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriver.Adapters.Validators;
using System;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationValidatorTestHelper
    {
        public Action DefaultValidation<T>(Location location = null, string message = null) where T : Exception
        {
            var  validator = new LocationValidator();
            return () => validator.DefaultValidation(location);
        }
    }
}
