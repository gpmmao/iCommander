using System.Collections.Generic;
using AutoMapper;
using Commander.Dtos;
using Commander.Models;
using Commander.Respository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/Commands")]
    [ApiController]
    public class CommandsController: Controller
    {
        private readonly ICommanderRepo _repository;// = new MockCommanderRepo();
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo rep,IMapper mapper){
            _repository = rep;
            _mapper = mapper;
        }
        [HttpGet]
        [EnableQuery()]
        public ActionResult <IEnumerable<Command>> GetAllcommnds()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //Get api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id){
            var commandItem = _repository.GetCommandbyId(id);
            if ( commandItem != null )
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto cmd)
        {
            var commandModel = _mapper.Map<Command>(cmd);
            _repository.CreateCommand(commandModel);

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id},commandReadDto);
           // return Ok(commandReadDto);
        }
        [HttpPut("id")]
        public ActionResult  UpdateCommand(int id, CommandUpdateDto commandUpdateDto){
            var commandinDb = _repository.GetCommandbyId(id);
            if ( commandinDb == null ){
                return NotFound();
            }
            _mapper.Map(commandUpdateDto,commandinDb);
            _repository.UpdateCommand(commandinDb);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}