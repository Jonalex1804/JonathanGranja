using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JonathanGranja.Models;

namespace JonathanGranja.Data
{
    public class JonathanGranjaContext : DbContext
    {
        public JonathanGranjaContext (DbContextOptions<JonathanGranjaContext> options)
            : base(options)
        {
        }

        public DbSet<JonathanGranja.Models.JGranja> JGranja { get; set; } = default!;
        public DbSet<JonathanGranja.Models.Carrera> Carrera { get; set; } = default!;
    }
}
