using System.Collections.Generic;
using System.Linq;
using Commander.Models;
using System;

namespace Commander.Respository
{
    public class CommanderRepo : ICommanderRepo
    {
        private CommanderContext _dbContext;
        public CommanderRepo(CommanderContext db)
        {
            _dbContext = db;
        }
        public IEnumerable<Command> GetAllCommands()
        {
          
            return _dbContext.Commands.ToList();
        }

        public Command GetCommandbyId(int id)
        {
           return _dbContext.Commands.SingleOrDefault(c=>c.Id == id);
        }

        public bool  SaveChanges()
        {
           return(  _dbContext.SaveChanges() > 0) ;
        }
        public void CreateCommand(Command cmd)
        {
            if ( cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd) );
            }

            _dbContext.Commands.Add(cmd);
            _dbContext.SaveChanges();
        }

        void ICommanderRepo.UpdateCommand(Command cmd)
        {
            
        }
    }
}