using System.Collections.Generic;
using Commander.Models;

namespace Commander.Respository
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandbyId(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
    } 
}