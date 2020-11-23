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
            if (location.Name.Length < 2) throw new ArgumentOutOfRangeException(null, "Name must be 2 or more characters");
            if (location.Name.Length > 12) throw new ArgumentOutOfRangeException(null, "Name must be less than 12 characters");
            if (string.IsNullOrEmpty(location.Address)) throw new PropertyCannotBeEmptyException("Address");
            if (string.IsNullOrEmpty(location.Owner)) throw new PropertyCannotBeEmptyException("Owner");

            if (location.Address.Length < 4)
            {
                throw new ArgumentOutOfRangeException(null, "Address Must be 4 or more Characters");
            }

            if (location.Address.Length >= 100)
            {
                throw new ArgumentOutOfRangeException(null, "Address Must less then 100 Characters");
            }

            if (string.IsNullOrEmpty(location.Owner))
            {
                throw new PropertyCannotBeEmptyException("Owner");
            }

            if (location.Owner.Length < 2)
            {
                throw new ArgumentOutOfRangeException(null, "Owner Must be 2 or more Characters");
            }

            if (location.Owner.Length >= 20)
            {
                throw new ArgumentOutOfRangeException(null, "Owner Must less then 20 Characters");
            }

            if (location.Id < 0) throw new ArgumentOutOfRangeException(null, "ID needs to 0 or more");
        }
    }
}
