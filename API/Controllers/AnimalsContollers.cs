using Application.Commands.AddAnimals;
using Application.Commands.DeleteAnimal;
using Application.Commands.UpdateAnimal;
using Application.Dtos;
using Application.Queries.GetAllAnimals;
using Application.Queries.GetAnimalById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]

    public class AnimalsController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public AnimalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
        }

        [HttpGet]
        [Route("getAnimalById/{animalId}")]
        public async Task<IActionResult> GetAnimalById(Guid animalId)
        {
            return Ok(await _mediator.Send(new GetAnimalByIdQuery(animalId)));
        }

        [HttpPost]
        [Route("addNewAnimal")]
        public async Task<IActionResult> AddAnimal([FromBody] AnimalDto newAnimal)
        {
            return Ok(await _mediator.Send(new AddAnimalsCommand(newAnimal)));
        }

        [HttpPut]
        [Route("updateAnimal/{animalId}")]
        public async Task<IActionResult> UpdateAnimal([FromBody] AnimalDto updatedAnimal, Guid animalId)
        {
            return Ok(await _mediator.Send(new UpdateAnimalCommand(updatedAnimal, animalId)));
        }

        [HttpDelete]
        [Route("deleteAnimal/{animalId}")]
        public async Task<IActionResult> DeleteAnimal( Guid animalId)
        {
            try
            {
                var animalDto = await _mediator.Send(new GetAnimalByIdQuery(animalId));

                if(animalDto == null)
                {
                    return NotFound(new { Error = "Id dose not exist." });

                }
                await _mediator.Send(new DeleteAnimalCommand(animalId));
                return Ok(new { Massage = $"Slected animal {animalDto.Name} has succefuly ben deleted" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Massage = "Something whent wrong." });
            }
            
        }
    }
}
