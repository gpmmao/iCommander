using System.Collections.Generic;
using Commander.Models;

namespace Commander.Respository
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Command> ICommanderRepo.GetAllCommands()
        {
            var command = new List<Command>
            {
                new Command {Id = 0, HowTo="Boil an egg",Line="Line 0", Platform="Ketle & Pan"},
                new Command {Id = 1, HowTo="Fry Meat",Line="Line 1",Platform="Table"},
                new Command {Id = 2, HowTo="Cut Bread",Line="Line 2",Platform="Get a Knife"}
             
            };
            return command;
        }

        Command ICommanderRepo.GetCommandbyId(int id)
        {
            return new Command{
                Id = 0,
                HowTo="Boil an egg",
                Platform="Ketle & Pan",
                Line = "Single line"
            };
        }

        bool ICommanderRepo.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}