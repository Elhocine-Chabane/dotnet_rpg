using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : IcharacterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character(){Id = 1, Name ="Elhocine" },
            new Character(){Id =2, Name = "Hakim"}
        };
        public async  Task<List<Character>> AddCharacter(Character newCharacter)
        {

            characters.Add(newCharacter);
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Character>> GetCharacters()
        {
            return characters ;
        }
    }
}
