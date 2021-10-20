using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xPingu.SharedLib.Models;

namespace xPingu.SharedLib.Data
{
    public class WarcraftContext : DbContext
    {
        public WarcraftContext (DbContextOptions<WarcraftContext> options)
            : base(options)
        {
        }

        public DbSet<xPingu.SharedLib.Models.wowDBitems> prices { get; set; }
    }
}
