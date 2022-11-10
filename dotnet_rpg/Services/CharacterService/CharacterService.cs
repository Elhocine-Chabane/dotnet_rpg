using AutoMapper;
using dotnet_rpg.DTOs.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : IcharacterService
    {
        private readonly IMapper _mapper;   
        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
            
        }
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character(){Id = 1, Name ="Elhocine" },
            new Character(){Id =2, Name = "Hakim"}
        };
        public async  Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            // comme je n'ai pas définit de Propretieté Id dans la classe AddCharacterDto je l'initiliase ici pour éviter qu'ellle soit émise à zéro à chaque fois 
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(x => x.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
            return serviceResponse;
        }

        

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>>
            { 
                Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList() 
            } ;
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> response= new ServiceResponse<GetCharacterDto>();
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
             ServiceResponse<GetCharacterDto> response =  new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(x => x.Id == updatedCharacter.Id); ;
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message =e.Message;
            }
            return response;
        }
    }
}
