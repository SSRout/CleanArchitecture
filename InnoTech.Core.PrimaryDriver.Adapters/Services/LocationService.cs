using InnoTech.Core.Entity;
using InnoTech.Core.Infratructure.Ports.Repositories;
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Services
{
    public class LocationService: ILocationService
    {
        public LocationService(ILocationRepository locationRepository)
        {
            if (locationRepository == null) throw new NullReferenceException("You need to have repositoty to pass");
        }

        public void Create(Location location)
        {
            if (location == null) throw new ParameterCannotBeNullException("Location");

            if (string.IsNullOrEmpty(location.Name)) throw new PropertyCannotBeEmptyException("Name");

            if (location.Name.Length < 2) throw new ArgumentOutOfRangeException("Name must be 2 or more characters");
        }
    }
}
