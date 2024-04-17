using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class GreetingContext : DbContext
    {
        public GreetingContext(DbContextOptions<GreetingContext> options) : base(options)
        { }

        public DbSet<Greeting> Greetings {get; set;}
    }
}