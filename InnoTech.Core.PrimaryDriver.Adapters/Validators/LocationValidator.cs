using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Validators
{
    public class LocationValidator: ILocationValidator
    {
        public void DefaultValidation(Location location)
        {
            if (location == null) throw new ParameterCannotBeNullException("Location");

            if (string.IsNullOrEmpty(location.Name)) throw new PropertyCannotBeEmptyException("Name");

            if (location.Name.Length < 2) throw new ArgumentOutOfRangeException("Name must be 2 or more characters");
        }
    }
}
