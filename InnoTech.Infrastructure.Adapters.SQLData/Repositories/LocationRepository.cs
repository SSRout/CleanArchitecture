using InnoTech.Core.Entity;
using InnoTech.Core.Infratructure.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Infrastructure.Adapters.SQLData.Repositories
{
    public class LocationRepository: ILocationRepository
    {
        private readonly EggProductionDbContext _ctx;

        public LocationRepository(EggProductionDbContext ctx)
        { 
            _ctx = ctx?? throw new NullReferenceException();
        }

        public void Add(Location location)
        {
            if(location==null) throw new NullReferenceException();
            _ctx.Add(location);
            _ctx.SaveChanges();
        }
    }
}
