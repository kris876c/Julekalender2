using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Julekalender.Models
{
    public class JulekalenderContext : DbContext
    {
        public JulekalenderContext (DbContextOptions<JulekalenderContext> options)
            : base(options)
        {
        }

        public DbSet<Julekalender.Models.Factoids> Factoids { get; set; }
    }
}
