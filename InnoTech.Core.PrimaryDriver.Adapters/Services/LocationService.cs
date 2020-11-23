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
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationValidator _locationValidator;

        public LocationService(ILocationRepository locationRepository,ILocationValidator locationValidator)
        {
            _locationRepository = locationRepository?? throw new ParameterCannotBeNullException("LocationRepository");
            _locationValidator = locationValidator?? throw new ParameterCannotBeNullException("LocationValidator");
        }

        public void Create(Location location)
        {
            _locationValidator.DefaultValidation(location);
            _locationRepository.Add(location);
        }
    }
}
