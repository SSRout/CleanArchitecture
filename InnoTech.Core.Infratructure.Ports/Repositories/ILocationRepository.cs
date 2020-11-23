using InnoTech.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Core.Infratructure.Ports.Repositories
{
    public interface ILocationRepository
    {
        void Add(Location location);
    }
}
