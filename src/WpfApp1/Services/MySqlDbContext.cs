using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entities;

namespace WpfApp1.Services;

internal class MySqlDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }

}
