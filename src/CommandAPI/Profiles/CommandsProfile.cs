using AutoMapper;
using CommandAPI.DTOs;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>(); //  our “source” is the CommandCreateDto (as will be supplied in our POST request body), and the target is our internal Command model
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    
    }
}
