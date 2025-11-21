using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using simple.Entidades;

namespace simple.Data
{
    public class simpleContext : DbContext
    {
        public simpleContext (DbContextOptions<simpleContext> options)
            : base(options)
        {
        }

        public DbSet<simple.Entidades.Articulo> Articulo { get; set; } = default!;
    }
}
