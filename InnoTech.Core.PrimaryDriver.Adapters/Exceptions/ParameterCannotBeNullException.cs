using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Exceptions
{
    public class ParameterCannotBeNullException: NullReferenceException
    {
        public ParameterCannotBeNullException(string parameterName="Unknown"):base($"{parameterName} Parameter Can't be null")
        {

        }
    }
}
