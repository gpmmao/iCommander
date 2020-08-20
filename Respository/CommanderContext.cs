using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Respository
{
    public class CommanderContext: DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext>opt) : base(opt)
        {

        }

        public DbSet<Command> Commands{get;set;}
    }
}