﻿using dotnet_rpg.Models;

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
        public async  Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {

            var serviceResponse = new ServiceResponse<List<Character>>();
            
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = character;
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Character>>> GetCharacters()
        {
            return new ServiceResponse<List<Character>>{ Data = characters} ;
        }
    }
}
