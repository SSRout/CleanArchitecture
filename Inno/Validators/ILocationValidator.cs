using InnoTech.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.PrimaryDriver.Ports.Services
{
    public interface ILocationValidator
    {
        public void DefaultValidation(Location location);
    }
}
