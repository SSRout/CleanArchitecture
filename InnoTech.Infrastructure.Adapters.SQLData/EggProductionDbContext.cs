using InnoTech.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace InnoTech.Infrastructure.Adapters.SQLData
{
    public class EggProductionDbContext:DbContext
    {
        public DbSet<Location> locations { get; set; }
    }
}
