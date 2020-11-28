using FluentAssertions;
using InnoTech.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InnoTech.Infrastructure.Adapters.SQLData.Test
{
    public class EggProductionDbContextTest
    {
        [Fact]
        public void EggProductionDbContext_IsTyoeOfDbContext()
        {
            var context = new EggProductionDbContext();
            context.Should().BeAssignableTo<DbContext>();
        }

        [Fact]
        public void EggProductionDbContext_ShouldHaveDbSetWithLocation()
        {
            var context = new EggProductionDbContext();
            context.locations.Should().BeAssignableTo<DbSet<Location>>();
        }
    }
}
