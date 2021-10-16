using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;
        private readonly IMapper _mapper;
        private readonly IAccommodationService _accommodationService;

        public PetController(IPetService service, IMapper mapper, IAccommodationService accommodationService)
        {
            _service = service;
            _mapper = mapper;
            _accommodationService = accommodationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTO>> GetPetById(int id)
        {
            Pet pet = await _service.GetPetById(id, false);

            if (pet is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PetDTO>(pet));
        }

        [HttpGet("getPetByName")]
        public async Task<ActionResult<PetDTO[]>> GetPetsByName(string name)
        {
            if (name is null)
            {
                return NotFound("Name can't be empity");
            }

            Pet[] pets = await _service.GetPetsByName(name, false);

            if (pets is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PetDTO[]>(pets));
        }

        [HttpPost]
        public async Task<ActionResult<PetDTO>> CreatePet(PetDTO petDTO)
        {
            if (! await _accommodationService.IsAccommodationFree(petDTO.AccommodationNumber))
            {
                return BadRequest("Accommodations is busy!");
            }

            int petId = await _service.CreatePet(_mapper.Map<Pet>(petDTO));
            
            if (petId > 0)
            {
                petDTO.Id = petId;
                return CreatedAtAction(nameof(GetPetById), new { id = petId }, petDTO);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PetDTO>> EditPet(int id, PetDTO petDTO)
        {
            if (id != petDTO.Id)
            {
                return BadRequest("Incorrect Id!");
            }

            PetDTO currentPet = _mapper.Map<PetDTO>(await _service.GetPetById(id, true));

            int oldAccommodationNumber = 0;
            if (currentPet.AccommodationNumber != petDTO.AccommodationNumber)
            {
                if (!await _accommodationService.IsAccommodationFree(petDTO.AccommodationNumber))
                {
                    return BadRequest("Accommodation is busy!");
                }

                oldAccommodationNumber = currentPet.AccommodationNumber;
            }

            if (await _service.UpdatePet(_mapper.Map<Pet>(petDTO), oldAccommodationNumber))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            Pet pet = await _service.GetPetById(id, false);

            if (pet is null)
            {
                return BadRequest();
            }

            if (await _service.DeletePet(pet))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}