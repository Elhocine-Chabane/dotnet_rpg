using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.DTOs.Character;

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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterservice.GetCharacters());
        }
        [HttpGet("OneCharacter{id}")]
        
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingleCharacter(int id)
        {
            return Ok(await _characterservice.GetCharacterById(id));

           
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterservice.AddCharacter(newCharacter));

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdatedCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterservice.UpdateCharacter(updatedCharacter);
            if(response.Data == null) 
                    return NotFound(response);


            return Ok(await _characterservice.UpdateCharacter(updatedCharacter));

        }


    }
}
