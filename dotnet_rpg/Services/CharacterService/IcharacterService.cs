using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface IcharacterService
    {

        Task<ServiceResponse<List<Character>>> GetCharacters();
       
        Task<ServiceResponse<Character>> GetCharacterById(int id);    
        Task<ServiceResponse<List<Character>>> AddCharacter(Character NewCharacter);


    }
}
