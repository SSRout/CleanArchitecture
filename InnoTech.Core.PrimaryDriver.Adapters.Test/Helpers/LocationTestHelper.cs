using InnoTech.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationTestHelper
    {
        public Location Location(string name="",string add="")
        {
            return new Location{
                Name=name ,
                Address=add
            };
        }

        public Location LocationWithoutName(string name = "")
        {
            return new Location
            {
                Name = name
            };
        }

        public Location LocationWithoutAddress(string address = "")
        {
            var location = LocationWithoutName("The Village");
            location.Address = address;
            return location;
        }

        public Location LocationWithoutOwner(string owner = "")
        {
            var location = LocationWithoutAddress("The Place");
            location.Owner = owner;
            return location;
        }

        public Location LocationWithoutId(int id = 0)
        {
            var location = LocationWithoutOwner("John doe");
            location.Id = id;
            return location;
        }

        public Location ValidLocation()
        {
            return new Location
            {
                Name = "The Village",
                Address = "The Place",
                Owner = "John Doe"
            };
        }

        public Location LocationWithoutAddress(string Address = "")
        {
            var location = GetValidLocation();
            location.Address = Address;
            return location;
        }

        public Location LocationWithoutOwner(string owner="")
        {
            var location = LocationWithoutAddress("add");
            location.Owner = owner;
            return location;
        }

        public Location LocationWithID(int id = 0)
        {
            var location = LocationWithoutOwner("owner");
            location.Id = id;
            return location;
        }
    }
}
