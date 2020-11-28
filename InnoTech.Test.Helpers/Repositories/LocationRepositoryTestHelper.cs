using InnoTech.Infrastructure.Adapters.SQLData;
using InnoTech.Infrastructure.Adapters.SQLData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnoTech.Test.Helpers.Repositories
{
    public class LocationRepositoryTestHelper
    {
        public LocationRepository GetValidLocationRepository()
        {
            return new LocationRepository(new EggProductionDbContext());
        }

        public LocationRepository GetLocationRepository(EggProductionDbContext context)
        {
            return new LocationRepository(context);
        }

        /*
         *   [Fact]
        public void DbContextTest()
        {
            var dbContextMock = new Mock<EggProductionDbContext>();
            var list = new List<Location>();
            var changeTrackerList = new List<Location>();
            var dbSetMock = new Mock<DbSet<Location>>();
            dbContextMock.Setup(c => c.Locations).ReturnsDbSet(list, dbSetMock);
            dbContextMock.Setup(c => c.Add(It.IsAny<Location>())).Callback<Location>((l) => changeTrackerList.Add(l));
            dbContextMock.Setup(c => c.SaveChanges()).Callback(() => list.AddRange(changeTrackerList));
            var repo = new LocationRepository(dbContextMock.Object);
            var location = new Location();
            repo.Add(location);
            dbContextMock.Verify(dbm => dbm.Add(location), Times.Once);
            dbContextMock.Verify(dbm => dbm.SaveChanges(), Times.Once);
            Assert.Collection(list,
                item => Assert.Equal(location, item)
            );
        }
        
        [Fact]
        public void DbContextTest3()
        {
            var locations = new List<Location>
            {
                new Location{Id = 1, Address = "aAaaaa", Name = "BEEee", Owner = "JOOHN"},
                new Location{Id = 2, Address = "bBbbbb", Name = "CEEee", Owner = "JIIILLL"},
            };
            var context = new Mock<EggProductionDbContext>();
            context.Setup(c => c.Locations).ReturnsDbSet(locations);
            var repo = new LocationRepository(context.Object);
            var actual = repo.ReadAll();
            var expected = locations.Select(l => new Location
            {   Id = l.Id,
                Address = l.Address
            }).OrderByDescending(l => l.Address).ToList();
            
            Assert.Equal(expected.Count(), actual.Count());
            var list = actual.Where(l1 =>
                expected.Any(l2 => 
                    l2.Address == l1.Address &&  
                    l2.Id == l1.Id && 
                    l2.Name == l1.Name && 
                    l2.Owner == l1.Owner)); 
            Assert.Equal(2, list.Count());
            var listFlipped = expected.Where(l1 =>
                actual.Any(l2 => 
                    l2.Address == l1.Address &&  
                    l2.Id == l1.Id && 
                    l2.Name == l1.Name && 
                    l2.Owner == l1.Owner)); 
            Assert.Equal(2, listFlipped.Count());
        }
         */

    }
}
