using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieTicketApi.Models;

namespace MovieTicketApi.Data
{
    public class MovieDbContext : DbContext

    {
        protected readonly IConfiguration Configuration;
        public MovieDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
        }

        public DbSet<Movie> Movies { get; set; }


    }
}