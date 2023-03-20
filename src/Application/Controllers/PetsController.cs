using System.Text.Json;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Interfaces;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    private readonly IPetService _service;
    private readonly IMapper _mapper;
    private readonly IAccommodationService _accommodationService;

    public PetsController(IPetService service, IMapper mapper, IAccommodationService accommodationService)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _accommodationService = accommodationService ?? throw new ArgumentNullException(nameof(accommodationService));
    }

    [HttpGet(Name = "GetPets")]
    [HttpHead]
    public async Task<ActionResult<PetDTO[]>> GetPets([FromQuery] PetParameters petParameters)
    {
        var paginatedPet = await _service.GetPetsAsync(petParameters);

        if (paginatedPet is null)
        {
            return NotFound();
        }

        var previousPageLink = paginatedPet.HasPreviousPage 
            ? CreateAuthorsResourceUri(petParameters, ResourceUriTypeEnum.PreviousPage) 
            : null;

        var nextPageLink = paginatedPet.HasNextPage
            ? CreateAuthorsResourceUri(petParameters, ResourceUriTypeEnum.NextPage)
            : null;

        var paginationMetadata = new {
            totalCount = paginatedPet.TotalPages,
            pageNumber = paginatedPet.PageNumber,
            previousPageLink = previousPageLink,
            nextPageLink = nextPageLink
        };

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(_mapper.Map<PetDTO[]>(paginatedPet));
    }

    private string CreateAuthorsResourceUri(PetParameters petParameters, ResourceUriTypeEnum type)
    {
        return type switch
        {
            ResourceUriTypeEnum.PreviousPage => 
                Url.Link("GetPets", new {
                    name = petParameters.Name,
                    healthState = petParameters.HealthState,
                    pageNumber = petParameters.PageNumber - 1,
                    pageSize = petParameters.PageSize,
                }),
            ResourceUriTypeEnum.NextPage => 
                Url.Link("GetPets", new {
                    name = petParameters.Name,
                    healthState = petParameters.HealthState,
                    pageNumber = petParameters.PageNumber + 1,
                    pageSize = petParameters.PageSize,
                }),
            _ => 
                Url.Link("GetPets", new {
                    name = petParameters.Name,
                    healthState = petParameters.HealthState,
                    pageNumber = petParameters.PageNumber,
                    pageSize = petParameters.PageSize,
                })
        };
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

    [HttpPost]
    public async Task<ActionResult<PetDTO>> Create(PetDTO petDTO)
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
    public async Task<ActionResult<PetDTO>> Edit(int id, PetDTO petDTO)
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
    public async Task<IActionResult> Delete(int id)
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
