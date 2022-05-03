#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using PortfolioAPI.Models;

namespace PortfolioAPI.Data
{
    public class PortfolioAPIContext : DbContext
    {
        public PortfolioAPIContext (DbContextOptions<PortfolioAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio.Models.About> About { get; set; }

        public DbSet<Portfolio.Models.Services> Services { get; set; }

        public DbSet<Portfolio.Models.TechnicalSkills> TechnicalSkills { get; set; }

        public DbSet<Portfolio.Models.SoftSkills> SoftSkills { get; set; }

        public DbSet<Portfolio.Models.Experience> Experience { get; set; }

        public DbSet<Portfolio.Models.Projects> Projects { get; set; }

        public DbSet<PortfolioAPI.Models.Contact> Contact { get; set; }
    }
}
