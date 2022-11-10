using dotnet_rpg.Models;
using dotnet_rpg.DTOs.Character;
namespace dotnet_rpg.Services.CharacterService
{
    public interface IcharacterService
    {

        Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters();
       
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);    
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto NewCharacter);


        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
    }
}
