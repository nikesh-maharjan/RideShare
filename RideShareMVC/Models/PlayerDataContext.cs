using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareMVC.Models
{
    public class PlayerDataContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerDataContext(DbContextOptions<PlayerDataContext> options):base(options)
        {
            Database.EnsureCreated();
            
        }

        public IQueryable<MonthlySpecial> MonthlySpecials
        {
            get
            {
                return new[]
                {
                    new MonthlySpecial
                    {
                        Key="calm",
                        name="california Calm Package",
                        Type="Daily spa Package",
                        Price=250,
                    },
                    new MonthlySpecial
                    {
                        Key="Smily",
                        name="california Calm Package",
                        Type="Daily spa Package",
                        Price=650,
                    },
                }.AsQueryable();
            } 
        }
    }
}
