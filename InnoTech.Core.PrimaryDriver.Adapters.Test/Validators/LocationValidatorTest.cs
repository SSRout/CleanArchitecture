﻿using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.Infratructure.Ports.Repositories;
using InnoTech.Core.PrimaryDriver.Adapters.Exceptions;
using InnoTech.Core.PrimaryDriver.Adapters.Services;
using InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers;
using InnoTech.Core.PrimaryDriver.Adapters.Validators;
using InnoTech.Core.PrimaryDriver.Ports.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
