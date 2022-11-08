using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;

namespace dotnet_rpg.Controllers
    
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IcharacterService _characterservice;

        public CharacterController(IcharacterService characterservice)
        {
            this._characterservice = characterservice;
        }
       
        [HttpGet("GettAll")]
        public async Task<ActionResult<List<Character>>> Get()
        {
            return Ok(await _characterservice.GetCharacters());
        }
        [HttpGet("OneCharacter{id}")]
        
        public async Task<ActionResult<Character>> GetSingleCharacter(int id)
        {
            return Ok(await _characterservice.GetCharacterById(id));

           
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            return Ok(await _characterservice.AddCharacter(newCharacter));

        }


    }
}
