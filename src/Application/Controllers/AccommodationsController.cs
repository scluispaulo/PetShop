using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccommodationsController : ControllerBase
{
    private readonly IAccommodationService _service;
    private readonly IMapper _mapper;

    public AccommodationsController(IAccommodationService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<AccommodationDTO[]>> GetAll()
    {
        Accommodation[] accommodations = await _service.GetAllAccommodations();

        if (accommodations is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AccommodationDTO[]>(accommodations));
    }

    [HttpGet("getFreeAccommodation")]
    public async Task<ActionResult<AccommodationDTO[]>> GetFreeAccommodationById()
    {
        Accommodation[] accommodations = await _service.GetFreeAccommodations();

        if (accommodations is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AccommodationDTO[]>(accommodations));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AccommodationDTO accommodationDTO)
    {
        if (id != accommodationDTO.Id)
        {
            return BadRequest("Incorrect Id!");
        }

        if (await _service.UpdateAccommodation(_mapper.Map<Accommodation>(accommodationDTO)))
        {
            return NoContent();
        }

        return BadRequest();
    }
}
