using InnoTech.Core.Entity;
using InnoTech.Core.Infratructure.Ports.Repositories;
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Adapters.Validators;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Services
{
    public class LocationService: ILocationService
    {
        private readonly ILocationValidator _locationValidator;

        public LocationService(ILocationRepository locationRepository,ILocationValidator locationValidator)
        {
            if (locationRepository == null) throw new ParameterCannotBeNullException("LocationRepository");
            if (locationValidator == null) throw new ParameterCannotBeNullException("LocationValidator");
            _locationValidator = locationValidator;
        }

        public void Create(Location location)
        {
            _locationValidator.DefaultValidation(location);
        }
    }
}
