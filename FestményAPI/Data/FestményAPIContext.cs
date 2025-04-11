using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FestményAPI.Model;

namespace FestményAPI.Data
{
    public class FestményAPIContext : DbContext
    {
        public FestményAPIContext (DbContextOptions<FestményAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FestményAPI.Model.Berles> Berles { get; set; } = default!;
    }
}
