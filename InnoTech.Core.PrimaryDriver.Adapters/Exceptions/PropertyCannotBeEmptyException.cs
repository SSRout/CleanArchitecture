using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Adapters.Exceptions
{
    public class PropertyCannotBeEmptyException: ArgumentOutOfRangeException
    {
        public PropertyCannotBeEmptyException(string propertyName = "Unknown") :
           base(null,$"{propertyName} needs to be a value")
        {
        }
    }
}
