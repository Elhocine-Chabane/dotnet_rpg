using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface IcharacterService
    {
        Task<List<Character>> GetCharacters(); 
        Task<Character> GetCharacterById(int id);    
        Task<List<Character>> AddCharacter(Character NewCharacter);


    }
}
