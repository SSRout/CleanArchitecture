using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers;
using System;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Validators
{
    public class LocationValidatorTest
    {
        private  LocationValidatorTestHelper _locationValidatorTestHelper;
        private  LocationTestHelper _locationTestHelper;

        public LocationValidatorTest()
        {
            _locationValidatorTestHelper =new  LocationValidatorTestHelper();
            _locationTestHelper =new  LocationTestHelper();
        }
        [Fact]
        public void DefaultValidation_WithNullLocation_ThrowsNewParameterCannotBeNullException()
        {
            _locationValidatorTestHelper.DefaultValidation<ParameterCannotBeNullException>();
        }

        [Fact]
        public void DefaultValidation_WithEmptyName_ThrowsPropertyCannotBeEmptyException()
        {
            _locationValidatorTestHelper.DefaultValidation<PropertyCannotBeEmptyException>(_locationTestHelper.Location(),"Name needs to be a value");
        }

        [Fact]
        public void DefaultValidation_withNameLessThan2Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(_locationTestHelper.Location("A"),"Name must be 2 or more characters");
        }

        [Fact]
        public void DefaultValidation_withNameMoreThan12Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(_locationTestHelper.Location("Abcdefghijklm"), "Name must be less than 12 characters");
        }

        [Fact]
        public void DefaultValidation_WithEmptyLocationAddress_ThrowsPropertyCannotBeEmptyException()
        {
            var location = _locationTestHelper.Location();
            location.Name = "Village";
            location.Address = "";
            _locationValidatorTestHelper.DefaultValidation<PropertyCannotBeEmptyException>(location,"Address needs to be a value");
        }

    }
}
