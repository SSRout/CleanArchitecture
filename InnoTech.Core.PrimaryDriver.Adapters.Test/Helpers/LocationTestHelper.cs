using InnoTech.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationTestHelper
    {
        public Location Location(string name="")
        {
            return new Location{
                Name=name 
            };
        }
        public Location GetValidLocation()
        {
            return new Location
            {
                Name = "The Place"
            };
        }
    }
}
